using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteca_Común
{
    /// <summary>
    /// Clase que se utiliza para publicar servicios en UDDI.
    /// </summary>
    public class Publish
    {
        private UDDISecurity.UDDI_Security_Port sClient;
        private UDDIPublish.UDDI_Publish_Port pClient;

        /// <summary>
        /// Crea una instancia de la clase para publicar en UDDI.
        /// </summary>
        /// <param name="direccion">Direccion del servidor UDDI</param>
        public Publish(string direccion) 
        {
            sClient = new UDDISecurity.UDDI_Security_Port();
            pClient = new UDDIPublish.UDDI_Publish_Port();

            sClient.Url = direccion + "/juddiv3/services/security";
            pClient.Url = direccion + "/juddiv3/services/publish";            
        }

        /// <summary>
        /// Publica un servicio en UDDI.
        /// </summary>
        /// <param name="nombre">Nombre del servicio.</param>
        /// <param name="descripcion">Descripción del servicio.</param>
        /// <param name="url">URL del servicio.</param>
        /// <returns>True si se ha publicado correctamente.</returns>
        public bool PublicarServicio(String nombre, String descripcion, String url)
        {
            try
            {

                UDDISecurity.get_authToken a = new UDDISecurity.get_authToken();
                a.userID = "Criludage";
                a.cred = "criludage";

                UDDISecurity.authToken authToken = sClient.get_authToken(a);

                if (authToken != null)
                {

                    // Token de autenticacion
                    string authInfo = authToken.authInfo;


                    /*
                     * Publicar tModel
                     */

                    UDDIPublish.save_tModel stm = new UDDIPublish.save_tModel();
                    stm.authInfo = authInfo;

                    UDDIPublish.tModel[] tmodels = new UDDIPublish.tModel[1];
                    UDDIPublish.tModel tmodel = new UDDIPublish.tModel();
                    UDDIPublish.overviewDoc[] overviewDocs = new UDDIPublish.overviewDoc[1];
                    UDDIPublish.overviewDoc overviewDoc = new UDDIPublish.overviewDoc();
                    UDDIPublish.overviewURL overviewUrl = new UDDIPublish.overviewURL();
                    UDDIPublish.description[] descriptions = new UDDIPublish.description[1];
                    UDDIPublish.description description = new UDDIPublish.description();


                    description.Value = descripcion;
                    descriptions[0] = description;

                    overviewUrl.Value = url;

                    overviewDoc.overviewURL = overviewUrl;
                    overviewDoc.description = descriptions;

                    overviewDocs[0] = overviewDoc;
                    tmodel.overviewDoc = overviewDocs;

                    UDDIPublish.name name = new UDDIPublish.name();
                    name.Value = nombre;

                    tmodel.name = name;

                    tmodel.description = descriptions;

                    tmodels[0] = tmodel;
                    stm.tModel = tmodels;

                    UDDIPublish.tModelDetail tmd = pClient.save_tModel(stm);

                    if (tmd != null && tmd.tModel.Length > 0)
                    {

                        string tmodelkey = tmd.tModel[0].tModelKey;

                        /*
                         * Publicar negocio
                         */

                        UDDIPublish.save_business svb = new UDDIPublish.save_business();
                        svb.authInfo = authInfo;

                        UDDIPublish.businessEntity[] bentities = new UDDIPublish.businessEntity[1];
                        UDDIPublish.businessEntity bentity = new UDDIPublish.businessEntity();

                        UDDIPublish.name[] bnames = new UDDIPublish.name[1];
                        UDDIPublish.name bname = new UDDIPublish.name();
                        bname.Value = nombre;

                        bnames[0] = bname;
                        bentity.name = bnames;

                        UDDIPublish.description[] bdescriptions = new UDDIPublish.description[1];
                        UDDIPublish.description bdescription = new UDDIPublish.description();
                        bdescription.Value = nombre;

                        bdescriptions[0] = bdescription;
                        bentity.description = bdescriptions;

                        bentities[0] = bentity;
                        svb.businessEntity = bentities;

                        UDDIPublish.businessDetail bdetail = pClient.save_business(svb);

                        if (bdetail != null && bdetail.businessEntity.Length > 0)
                        {
                            string businesskey = bdetail.businessEntity[0].businessKey;

                            /*
                             * Publicar servicio
                             */
                            UDDIPublish.save_service svs = new UDDIPublish.save_service();

                            svs.authInfo = authInfo;

                            UDDIPublish.businessService[] bservices = new UDDIPublish.businessService[1];
                            UDDIPublish.businessService bservice = new UDDIPublish.businessService();
                            bservice.businessKey = businesskey;

                            bservice.name = bnames;
                            bservice.description = bdescriptions;

                            UDDIPublish.bindingTemplate[] btemplates = new UDDIPublish.bindingTemplate[1];
                            UDDIPublish.bindingTemplate btemplate = new UDDIPublish.bindingTemplate();

                            UDDIPublish.accessPoint acpoint = new UDDIPublish.accessPoint();
                            acpoint.Value = url;

                            btemplate.accessPoint = acpoint;

                            UDDIPublish.tModelInstanceInfo[] tminfos = new UDDIPublish.tModelInstanceInfo[1];
                            UDDIPublish.tModelInstanceInfo tminfo = new UDDIPublish.tModelInstanceInfo();
                            tminfo.tModelKey = tmodelkey;


                            UDDIPublish.instanceDetails idetail = new UDDIPublish.instanceDetails();

                            idetail.overviewDoc = overviewDocs;

                            tminfo.instanceDetails = idetail;
                            tminfos[0] = tminfo;
                            btemplate.tModelInstanceDetails = tminfos;
                            btemplates[0] = btemplate;
                            bservice.bindingTemplates = btemplates;
                            bservices[0] = bservice;
                            svs.businessService = bservices;

                            UDDIPublish.serviceDetail sdetail = pClient.save_service(svs);

                            if (sdetail != null && sdetail.businessService.Length > 0)
                            {
                                return true;
                            }
                        }
                    }
                }

                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }

    /// <summary>
    /// Clase que se utiliza para buscar servicios en UDDI.
    /// </summary>
    public class Inquiry
    {
        private UDDIInquiry.UDDI_Inquiry_Port p;

        /// <summary>
        /// Crea una instancia de la clase para buscar servicio.
        /// </summary>
        /// <param name="direccion">Dirección del servidor UDDI</param>
        public Inquiry(string direccion) 
        {
            p = new UDDIInquiry.UDDI_Inquiry_Port();
            p.Url = direccion + "/juddiv3/services/inquiry";            
        }

        /// <summary>
        /// Devuelve el punto de acceso asociado a un servicio.
        /// </summary>
        /// <param name="nombre">Nombre del servicio.</param>
        /// <returns>Dirección de acceso al servicio o NULL</returns>
        public String PuntoAccesoServicio(string nombre)
        {
            try
            {
                UDDIInquiry.find_service fS = new UDDIInquiry.find_service();

                UDDIInquiry.name[] names = new UDDIInquiry.name[1];
                UDDIInquiry.name name = new UDDIInquiry.name();
                name.Value = nombre;
                names[0] = name;
                fS.name = names;

                UDDIInquiry.serviceList lista = p.find_service(fS);
                UDDIInquiry.serviceInfo[] infos = lista.serviceInfos;

                if (infos != null && infos.Length > 0)
                {

                    string serviceKey = infos[0].serviceKey;

                    UDDIInquiry.get_serviceDetail getSd = new UDDIInquiry.get_serviceDetail();
                    string[] keys = new string[1];
                    keys[0] = serviceKey;
                    getSd.serviceKey = keys;

                    UDDIInquiry.serviceDetail sdetail = p.get_serviceDetail(getSd);

                    if (sdetail != null && sdetail.businessService.Length > 0)
                    {
                        if (sdetail.businessService[0].bindingTemplates.Length > 0)
                        {
                            return sdetail.businessService[0].bindingTemplates[0].accessPoint.Value;
                        }
                    }
                }

                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
