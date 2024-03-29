﻿using System;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using OpenPop.Mime.Decode;
using OpenPop.Common;

namespace OpenPop.Mime.Header
{
	///<summary>
	/// Utility class that divides a message into a body and a header.<br/>
	/// The header is then parsed to a strongly typed <see cref="MessageHeader"/> object.
	///</summary>
	internal static class HeaderExtractor
	{
		/// <summary>
		/// Find the end of the header section in a byte array.<br/>
		/// The headers have ended when a blank line is found
		/// </summary>
		/// <param name="messageContent">The full message stored as a byte array</param>
		/// <returns>The position of the line just after the header end blank line</returns>
		private static int FindHeaderEndPosition(byte[] messageContent)
		{
			// Convert the byte array into a stream
			using (Stream stream = new MemoryStream(messageContent))
			{
				while (true)
				{
					// Read a line from the stream. We know headers are in US-ASCII
					// therefore it is not problem to read them as such
					string line = StreamUtility.ReadLineAsAscii(stream);

					// If we have read the full messageContent but no empty line has been found
					// This will not happen if a valid message was passed to this method
					if (line == null)
						throw new ArgumentException("Message does not contain a empty line which tells where the headers of the message end");

					// The end of headers is signaled when a blank line is found
					if (line.Length == 0)
						return (int)stream.Position;
				}
			}
		}

		/// <summary>
		/// Extract the header part and body part of a message.<br/>
		/// The headers are then parsed to a strongly typed <see cref="MessageHeader"/> object.
		/// </summary>
		/// <param name="fullRawMessage">The full message in bytes where header and body needs to be extracted from</param>
		/// <param name="headers">The extracted header parts of the message</param>
		/// <param name="body">The body part of the message</param>
		/// <exception cref="ArgumentNullException">If <paramref name="fullRawMessage"/> is <see langword="null"/></exception>
		public static void ExtractHeadersAndBody(byte[] fullRawMessage, out MessageHeader headers, out byte[] body)
		{
			if(fullRawMessage == null)
				throw new ArgumentNullException("fullRawMessage");

			// Find the end location of the headers
			int endOfHeaderLocation = FindHeaderEndPosition(fullRawMessage);

			// The headers are always in ASCII - therefore we can convert the header part into a string
			// using US-ASCII encoding
			string headersString = Encoding.ASCII.GetString(fullRawMessage, 0, endOfHeaderLocation);

			// Now parse the headers to a NameValueCollection
			NameValueCollection headersUnparsedCollection = ExtractHeaders(headersString);

			// Use the NameValueCollection to parse it into a strongly-typed MessageHeader header
			headers = new MessageHeader(headersUnparsedCollection);

			// Since we know where the headers end, we also know where the body is
			// Copy the body part into the body parameter
			body = new byte[fullRawMessage.Length - endOfHeaderLocation];
			Array.Copy(fullRawMessage, endOfHeaderLocation, body, 0, body.Length);
		}

		/// <summary>
		/// Method that takes a full message and extract the headers from it.
		/// </summary>
		/// <param name="messageContent">The message to extract headers from. Does not need the body part. Needs the empty headers end line.</param>
		/// <returns>A collection of Name and Value pairs of headers</returns>
		/// <exception cref="ArgumentNullException">If <paramref name="messageContent"/> is <see langword="null"/></exception>
		private static NameValueCollection ExtractHeaders(string messageContent)
		{
			if(messageContent == null)
				throw new ArgumentNullException("messageContent");

			NameValueCollection headers = new NameValueCollection();

			using (StringReader messageReader = new StringReader(messageContent))
			{
				// Read until all headers have ended.
				// The headers ends when an empty line is encountered
				string line;
				while (!string.Empty.Equals(line = messageReader.ReadLine()))
				{
					// Split into name and value
					string[] splittedValue = Utility.GetHeadersValue(line);

					// First index is header name
					string headerName = splittedValue[0];

					// Second index is the header value.
					// Use a StringBuilder since the header value may be continued on the next line
					StringBuilder headerValue = new StringBuilder(splittedValue[1]);

					// Keep reading until we would hit next header
					// This if for handling multi line headers
					while (IsMoreLinesInHeaderValue(messageReader))
					{
						// Unfolding is accomplished by simply removing any CRLF
						// that is immediately followed by WSP
						// This was done using ReadLine
						string moreHeaderValue = messageReader.ReadLine();

						// If this exception is ever raised, there is an serious algorithm failure
						// IsMoreLinesInHeaderValue does not return true if the next line does not exist
						// This check is only included to stop the nagging "possibly null" code analysis hint
						if (moreHeaderValue == null)
							throw new ArgumentException("This will never happen");

						// If a header is continued the first whitespace character is not needed.
						// It is only there to tell that the header was continued
						headerValue.Append(moreHeaderValue, 1, moreHeaderValue.Length - 1);
					}

					// Now we have the name and full value. Add it
					headers.Add(headerName, headerValue.ToString());
				}
			}

			return headers;
		}

		/// <summary>
		/// Check if the next line is part of the current header value we are parsing by
		/// peeking on the next character of the <see cref="TextReader"/>.<br/>
		/// This should only be called while parsing headers.
		/// </summary>
		/// <param name="reader">The reader from which the header is read from</param>
		/// <returns><see langword="true"/> if multi-line header. <see langword="false"/> otherwise</returns>
		private static bool IsMoreLinesInHeaderValue(TextReader reader)
		{
			int peek = reader.Peek();
			if (peek == -1)
				return false;

			char peekChar = (char)peek;

			// A multi line header must have a whitespace character
			// on the next line if it is to be continued
			return peekChar == ' ' || peekChar == '\t';
		}
	}
}