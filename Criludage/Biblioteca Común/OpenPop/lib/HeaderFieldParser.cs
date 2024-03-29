﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using OpenPop.Mime.Decode;
using OpenPop.Common.Logging;

namespace OpenPop.Mime.Header
{
	/// <summary>
	/// Class that can parse different fields in the header sections of a MIME message.
	/// </summary>
	internal static class HeaderFieldParser
	{
		/// <summary>
		/// Parses the Content-Transfer-Encoding header.
		/// </summary>
		/// <param name="headerValue">The value for the header to be parsed</param>
		/// <returns>A <see cref="ContentTransferEncoding"/></returns>
		/// <exception cref="ArgumentNullException">If <paramref name="headerValue"/> is <see langword="null"/></exception>
		/// <exception cref="ArgumentException">If the <paramref name="headerValue"/> could not be parsed to a <see cref="ContentTransferEncoding"/></exception>
		public static ContentTransferEncoding ParseContentTransferEncoding(string headerValue)
		{
			if(headerValue == null)
				throw new ArgumentNullException("headerValue");

			switch (headerValue.Trim().ToUpperInvariant())
			{
				case "7BIT":
					return ContentTransferEncoding.SevenBit;

				case "8BIT":
					return ContentTransferEncoding.EightBit;

				case "QUOTED-PRINTABLE":
					return ContentTransferEncoding.QuotedPrintable;

				case "BASE64":
					return ContentTransferEncoding.Base64;

				case "BINARY":
					return ContentTransferEncoding.Binary;

				default:
					throw new ArgumentException("Unknown ContentTransferEncoding: " + headerValue);
			}
		}

		/// <summary>
		/// Parses an ImportanceType from a given Importance header value.
		/// </summary>
		/// <param name="headerValue">The value to be parsed</param>
		/// <returns>A <see cref="MailPriority"/>. If the <paramref name="headerValue"/> is not recognized, Normal is returned.</returns>
		/// <exception cref="ArgumentNullException">If <paramref name="headerValue"/> is <see langword="null"/></exception>
		public static MailPriority ParseImportance(string headerValue)
		{
			if(headerValue == null)
				throw new ArgumentNullException("headerValue");

			switch (headerValue.ToUpperInvariant())
			{
				case "5":
				case "HIGH":
					return MailPriority.High;

				case "3":
				case "NORMAL":
					return MailPriority.Normal;

				case "1":
				case "LOW":
					return MailPriority.Low;

				default:
					DefaultLogger.Log.LogDebug("HeaderFieldParser: Unknown importance value: \"" + headerValue + "\". Using default of normal importance.");
					return MailPriority.Normal;
			}
		}

		/// <summary>
		/// Parses a the value for the header Content-Type to 
		/// a <see cref="ContentType"/> object.
		/// </summary>
		/// <param name="headerValue">The value to be parsed</param>
		/// <returns>A <see cref="ContentType"/> object</returns>
		/// <exception cref="ArgumentNullException">If <paramref name="headerValue"/> is <see langword="null"/></exception>
		public static ContentType ParseContentType(string headerValue)
		{
			if(headerValue == null)
				throw new ArgumentNullException("headerValue");

			// We create an empty Content-Type which we will fill in when we see the values
			ContentType contentType = new ContentType();

			// Now decode the parameters
			List<KeyValuePair<string, string>> parameters = Rfc2231Decoder.Decode(headerValue);

			foreach (KeyValuePair<string, string> keyValuePair in parameters)
			{
				string key = keyValuePair.Key.Trim();
				string value = keyValuePair.Value.Trim();
				switch (key)
				{
					case "":
						// This is the MediaType - it has no key since it is the first one mentioned in the
						// headerValue and has no = in it.
						contentType.MediaType = value;
						break;

					case "boundary":
						contentType.Boundary = Utility.RemoveQuotesIfAny(value);
						break;

					case "charset":
						string toInsert = Utility.RemoveQuotesIfAny(value);
						contentType.CharSet = toInsert;
						break;

					case "name":
						contentType.Name = EncodedWord.Decode(Utility.RemoveQuotesIfAny(value));
						break;

					default:
						// This is to shut up the code help that is saying that contentType.Parameters
						// can be null - which it cant!
						if(contentType.Parameters == null)
							throw new Exception("The ContentType parameters property is null. This will never be thrown.");

						// We add the unknown value to our parameters list
						// "Known" unknown values are:
						// - title
						// - report-type
						contentType.Parameters.Add(key, value);
						break;
				}
			}

			return contentType;
		}

		/// <summary>
		/// Parses a the value for the header Content-Disposition to a <see cref="ContentDisposition"/> object.
		/// </summary>
		/// <param name="headerValue">The value to be parsed</param>
		/// <returns>A <see cref="ContentDisposition"/> object</returns>
		/// <exception cref="ArgumentNullException">If <paramref name="headerValue"/> is <see langword="null"/></exception>
		public static ContentDisposition ParseContentDisposition(string headerValue)
		{
			if (headerValue == null)
				throw new ArgumentNullException("headerValue");

			// See http://www.ietf.org/rfc/rfc2183.txt for RFC definition

			// Create empty ContentDisposition - we will fill in details as we read them
			ContentDisposition contentDisposition = new ContentDisposition();

			// Now decode the parameters
			List<KeyValuePair<string, string>> parameters = Rfc2231Decoder.Decode(headerValue);

			foreach (KeyValuePair<string, string> keyValuePair in parameters)
			{
				string key = keyValuePair.Key.Trim();
				string value = keyValuePair.Value;
				switch (key)
				{
					case "":
						// This is the DispisitionType - it has no key since it is the first one
						// and has no = in it.
						contentDisposition.DispositionType = value;
						break;

					case "filename":
						// The filename might be in qoutes, and it might be encoded-word encoded
						contentDisposition.FileName = EncodedWord.Decode(Utility.RemoveQuotesIfAny(value));
						break;

					case "creation-date":
						// Notice that we need to create a new DateTime because of a failure in .NET 2.0.
						// The failure is: you cannot give contentDisposition a DateTime with a Kind of UTC
						// It will set the CreationDate correctly, but when trying to read it out it will throw an exception.
						// It is the same with ModificationDate and ReadDate.
						// This is fixed in 4.0 - maybe in 3.0 too.
						// Therefore we create a new DateTime which have a DateTimeKind set to unspecified
						DateTime creationDate = new DateTime(Rfc2822DateTime.StringToDate(value.Replace("\"", "")).Ticks);
						contentDisposition.CreationDate = creationDate;
						break;

					case "modification-date":
						DateTime midificationDate = new DateTime(Rfc2822DateTime.StringToDate(value.Replace("\"", "")).Ticks);
						contentDisposition.ModificationDate = midificationDate;
						break;

					case "read-date":
						DateTime readDate = new DateTime(Rfc2822DateTime.StringToDate(value.Replace("\"", "")).Ticks);
						contentDisposition.ReadDate = readDate;
						break;

					case "size":
						contentDisposition.Size = int.Parse(value, CultureInfo.InvariantCulture);
						break;

					default:
						throw new ArgumentException("Unknown parameter in Content-Disposition. Ask developer to fix!");
				}
			}

			return contentDisposition;
		}

		/// <summary>
		/// Parse a character set into an encoding.
		/// </summary>
		/// <param name="characterSet">The character set to parse</param>
		/// <returns>An encoding which corresponds to the character set</returns>
		/// <exception cref="ArgumentNullException">If <paramref name="characterSet"/> is <see langword="null"/></exception>
		public static Encoding ParseCharsetToEncoding(string characterSet)
		{
			if (characterSet == null)
				throw new ArgumentNullException("characterSet");

			string charSetUpper = characterSet.ToUpperInvariant();
			if (charSetUpper.Contains("WINDOWS") || charSetUpper.Contains("CP"))
			{
				// It seems the character set contains an codepage value, which we should use to parse the encoding
				charSetUpper = charSetUpper.Replace("CP", ""); // Remove cp
				charSetUpper = charSetUpper.Replace("WINDOWS", ""); // Remove windows
				charSetUpper = charSetUpper.Replace("-", ""); // Remove - which could be used as cp-1554

				// Now we hope the only thing left in the characterSet is numbers.
				int codepageNumber = int.Parse(charSetUpper, CultureInfo.InvariantCulture);

				return Encoding.GetEncoding(codepageNumber);
			}

			// It seems there is no codepage value in the characterSet. It must be a named encoding
			return Encoding.GetEncoding(characterSet);
		}

		/// <summary>
		/// Parses an ID like Message-Id and Content-Id.<br/>
		/// Example:<br/>
		/// <c>&lt;test@test.com&gt;</c><br/>
		/// into<br/>
		/// <c>test@test.com</c>
		/// </summary>
		/// <param name="headerValue">The id to parse</param>
		/// <returns>A parsed ID</returns>
		public static string ParseID(string headerValue)
		{
			// Remove whitespace in front and behind since
			// whitespace is allowed there
			// Remove the last > and the first <
			return headerValue.Trim().TrimEnd('>').TrimStart('<');
		}

		/// <summary>
		/// Parses multiple IDs from a single string like In-Reply-To.
		/// </summary>
		/// <param name="headerValue">The value to parse</param>
		/// <returns>A list of IDs</returns>
		public static List<string> ParseMultipleIDs(string headerValue)
		{
			List<string> returner = new List<string>();

			// Split the string by >
			// We cannot use ' ' (space) here since this is a possible value:
			// <test@test.com><test2@test.com>
			string[] ids = headerValue.Trim().Split(new[] { '>' }, StringSplitOptions.RemoveEmptyEntries);
			foreach (string id in ids)
			{
				returner.Add(ParseID(id));
			}

			return returner;
		}
	}
}