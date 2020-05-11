using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FxSenderSms.Class
{
    class BxConectarSqlServerCloud
    {
        private const string cadenaConectDbsms = "sqldb_connection_dbsms";
        private const string cadenaConectDbris = "sqldb_connection_dbris";

        public string StringConnectionDbris { get; set; }
        public string StringConnectionDbSms { get; set; }


        public BxConectarSqlServerCloud()
        {
            StringConnectionDbris = Environment.GetEnvironmentVariable(cadenaConectDbris);
            StringConnectionDbSms = Environment.GetEnvironmentVariable(cadenaConectDbsms);
        }

        public CxKeysWebServices GetKeysWebServil(CxElectronicSendSms sms)
        {
            CxKeysWebServices keys = new CxKeysWebServices();

            //Crea la conexion
            using (var connection = new SqlConnection(StringConnectionDbris))
            {
                try
                {
                    //Abre la conexion
                    connection.Open();
                    // Crea el String con el comando a ejecutar en la BD (se debe llamar BD_esquema_tabla)
                    string query = "SELECT url_send,[user],password " +
                                    " FROM dbris.dbo.TBL_MASTER_PARAMETER_PROVIDERS_ELECTRONIC_SEND " +
                                    " WHERE id_provider  = @id_provider " +
                                    " and id_service = @id_service " +
                                    " and activefx= @active";
                    System.Console.WriteLine(query);

                    //Realiza el Insert en la BD 
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = query;

                        cmd.Parameters.Add("@id_provider", SqlDbType.Int);
                        cmd.Parameters["@id_provider"].Value = sms.IdProvider;
                        cmd.Parameters.Add("@id_service", SqlDbType.Int);
                        cmd.Parameters["@id_service"].Value = sms.IdService;
                        cmd.Parameters.Add("@active", SqlDbType.Int);
                        cmd.Parameters["@active"].Value = sms.IdState;

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                keys.Url_send = (string)reader["url_send"].ToString();
                                keys.User = (string)reader["user"].ToString();
                                keys.Password = (string)reader["password"].ToString();
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    // Captura el error
                    System.Console.WriteLine(ex.ToString());
                    return null;

                }
                finally
                {
                    //Cierra la conexion
                    connection.Close();
                }
            }

            return keys;

        }

        public bool SaveSms(CxElectronicSendSms sms)
        {

            //Crea la conexion
            using (var connection = new SqlConnection(StringConnectionDbSms))
            {
                try
                {
                    sms.IdElectronicSend = GetIdElectronicSendSms();
                    //Abre la conexion
                    connection.Open();
                    // Crea el String con el comando a ejecutar en la BD (se debe llamar BD_esquema_tabla)
                    string recordInsert = "INSERT INTO dbsms.dbo.TBL_STG_ELECTRONIC_SEND_SMS (" +
                        "id_electronic_send, " +
                        "id_provider, " +
                        "id_service, " +
                        "id_client, " +
                        "id_product, " +
                        "Id_campain, " +
                        "[mod], " +
                        "recipient, " +
                        "file_name, " +
                        "hour_send, ";
                    if (sms.IdService != 6)
                    {
                        recordInsert += "len_message,message, " +
                        "quantity_real_sms, ";
                    }
                    recordInsert += "Message_id, ";
                    if (sms.IdService == 2 || sms.IdService == 4 || sms.IdService == 6)
                    {
                        recordInsert += "url_attached, ";
                    }
                    if (sms.IdService == 5 || sms.IdService == 6)
                    {
                        recordInsert += "[language], ";
                    }
                    recordInsert += "id_state, " +
                        "id_detail_state, " +
                        "channel" +
                        ") VALUES (" +
                        "@id_electronic_send, " +
                        "@id_provider, " +
                        "@id_service, " +
                        "@id_client, " +
                        "@id_product, " +
                        "@id_campain, " +
                        "@mod, " +
                        "@recipient, " +
                        "@file_name, " +
                        "@hour_send, ";
                    if (sms.IdService != 6)
                    {
                        recordInsert += "@len_message,@message, " +
                        "@quantity_real_sms, ";
                    }
                    recordInsert += "@Message_id, ";
                    if (sms.IdService == 2 || sms.IdService == 4 || sms.IdService == 6)
                    {
                        recordInsert += "@url_attached, ";
                    }
                    if (sms.IdService == 5 || sms.IdService == 6)
                    {
                        recordInsert += "@language, ";
                    }
                    recordInsert += "@id_state, " +
                        "@id_detail_state, " +
                        "@channel" +
                        ")";

                    System.Console.WriteLine(recordInsert);
                    //Realiza el Insert en la BD 
                    using (SqlCommand cmd = new SqlCommand(recordInsert, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = recordInsert;

                        cmd.Parameters.Add("@id_electronic_send", SqlDbType.Int);
                        cmd.Parameters["@id_electronic_send"].Value = sms.IdElectronicSend;


                        cmd.Parameters.Add("@id_provider", SqlDbType.Int);
                        cmd.Parameters["@id_provider"].Value = sms.IdProvider;

                        cmd.Parameters.Add("@id_service", SqlDbType.Int);
                        cmd.Parameters["@id_service"].Value = sms.IdService;

                        cmd.Parameters.Add("@id_client", SqlDbType.Int);
                        cmd.Parameters["@id_client"].Value = sms.IdClient;

                        cmd.Parameters.Add("@id_product", SqlDbType.Int);
                        cmd.Parameters["@id_product"].Value = sms.IdProduct;

                        cmd.Parameters.Add("@id_campain", SqlDbType.NVarChar, -1).Value = sms.IdCampain.ToString();

                        cmd.Parameters.Add("@mod", SqlDbType.Int);
                        cmd.Parameters["@mod"].Value = sms.Mod;

                        cmd.Parameters.Add("@recipient", SqlDbType.NVarChar, -1).Value = sms.Recipient.ToString();
                        cmd.Parameters.Add("@file_name", SqlDbType.NVarChar, -1).Value = sms.FileName.ToString();
                        cmd.Parameters.Add("@hour_send", SqlDbType.Int);
                        cmd.Parameters["@hour_send"].Value = sms.HourSend;


                        if (sms.IdService != 6)
                        {
                            cmd.Parameters.Add("@len_message", SqlDbType.Int);
                            cmd.Parameters["@len_message"].Value = sms.LenMessage;

                            cmd.Parameters.Add("@message", SqlDbType.NVarChar, -1).Value = sms.Message.ToString();

                            cmd.Parameters.Add("@quantity_real_sms", SqlDbType.Int);
                            cmd.Parameters["@quantity_real_sms"].Value = sms.QuantityRealSms;
                        }

                        cmd.Parameters.Add("@Message_id", SqlDbType.NVarChar, -1).Value = sms.MessageId.ToString();

                        if (sms.IdService == 2 || sms.IdService == 4 || sms.IdService == 6)
                        {
                            cmd.Parameters.Add("@url_attached", SqlDbType.NVarChar, -1).Value = sms.UrlAttached.ToString();
                        }
                        if (sms.IdService == 5 || sms.IdService == 6)
                        {
                            cmd.Parameters.Add("@language", SqlDbType.NVarChar, -1).Value = sms.Language.ToString();
                        }

                        cmd.Parameters.Add("@id_state", SqlDbType.Int);
                        cmd.Parameters["@id_state"].Value = sms.IdState;

                        cmd.Parameters.Add("@id_detail_state", SqlDbType.Int);
                        cmd.Parameters["@id_detail_state"].Value = sms.IdDetailState;

                        cmd.Parameters.Add("@channel", SqlDbType.NVarChar, -1).Value = sms.Channel.ToString();

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Captura el error
                    System.Console.WriteLine(ex.ToString());
                    return false;

                }
                finally
                {
                    //Cierra la conexion
                    connection.Close();
                }

            }


        }

        public bool SaveSmsControl(CxElectronicSendSms sms)
        {
                //Crea la conexion
                using (var connection = new SqlConnection(StringConnectionDbSms))
                {
                    try
                    {
                        //Abre la conexion
                        connection.Open();
                        // Crea el String con el comando a ejecutar en la BD (se debe llamar BD_esquema_tabla)
                        string recordInsert = "INSERT INTO dbsms.dbo.TBL_CONTROL_ELECTRONIC_SEND_SMS (" +
                            "id_client," +
                            "id_product," +
                            "id_service," +
                            "id_campain," +
                            "file_name," +
                            "quantity_required" +
                            ")	VALUES (" +
                            "@id_client," +
                            "@id_product," +
                            "@id_service," +
                            "@id_campain," +
                            "@file_name," +
                            "@quantity_required" +
                            ") ";

                        System.Console.WriteLine(recordInsert);
                        //Realiza el Insert en la BD 
                        using (SqlCommand cmd = new SqlCommand(recordInsert, connection))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = recordInsert;

                            cmd.Parameters.Add("@id_client", SqlDbType.Int);
                            cmd.Parameters["@id_client"].Value = sms.IdClient;

                            cmd.Parameters.Add("@id_product", SqlDbType.Int);
                            cmd.Parameters["@id_product"].Value = sms.IdProduct;

                            cmd.Parameters.Add("@id_service", SqlDbType.Int);
                            cmd.Parameters["@id_service"].Value = sms.IdService;

                            cmd.Parameters.Add("@id_campain", SqlDbType.NVarChar, -1).Value = sms.IdCampain.ToString();

                            cmd.Parameters.Add("@file_name", SqlDbType.NVarChar, -1).Value = sms.FileName.ToString();

                            cmd.Parameters.Add("@quantity_required", SqlDbType.Int);
                            cmd.Parameters["@quantity_required"].Value = 1;

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Captura el error
                        System.Console.WriteLine(ex.ToString());
                        return false;
                    }
                    finally
                    {
                        //Cierra la conexion
                        connection.Close();
                    }

                }

        }

        private int GetIdElectronicSendSms()
        {

            //Crea la conexion
            using (var connection = new SqlConnection(StringConnectionDbSms))
            {
                try
                {
                    //Abre la conexion
                    connection.Open();
                    // Crea el String con el comando a ejecutar en la BD (se debe llamar BD_esquema_tabla)
                    string query = "select max(id_electronic_send)+1 as num " +
                                    "from dbsms.dbo.TBL_STG_ELECTRONIC_SEND_SMS";
                    System.Console.WriteLine(query);

                    //Realiza el Insert en la BD 
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = query;

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return int.Parse(reader["num"].ToString());

                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    // Captura el error
                    System.Console.WriteLine(ex.ToString());
                    return 1;

                }
                finally
                {
                    //Cierra la conexion
                    connection.Close();
                }
            }

            return 1;

        }





    }


}
