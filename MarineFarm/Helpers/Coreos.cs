using MarineFarm.Auth;

namespace MarineFarm.Helpers
{
    /// <summary>
    /// clase para generar los cuerpos de los correos
    /// </summary>
    public class Coreos
    {
        /// <summary>
        /// cuerpo del correo
        /// </summary>
        public string body { get; set; } = string.Empty;
        /// <summary>
        /// para almacenar la direccion de las politicas
        /// </summary>
        public readonly string Politica = "/DireccionPoliticas";
        /// <summary>
        /// Terminos
        /// </summary>
        public readonly string Terminos = "/DireccionTerminos";
   

        #region correo pruebas
        /// <summary>
        /// para correo de pruebas
        /// </summary>
        public Coreos()
        {
            this.body = "<h3> Hola Mundo </h3>";
        }



        #endregion

        #region nuevo Usuario

        /// <summary>
        /// para generar correo de nuevos usuarios
        /// </summary>
        /// <param name="email"></param>
        /// <param name="psw"></param>
        public Coreos(Usuario us, string psw, string url = "https://www.granjamar.cl/")
        {
            string email = us == null || string.IsNullOrEmpty(us.Email) ? "fail@yopmail.com" : us.Email; 
            string cuerpo = @"
                


        <div style='margin:0px auto;max-width:600px;'>
            <table align='center' border='0' cellpadding='0' cellspacing='0' role='presentation' style='width:100%;'>
                <tbody>
                    <tr>
                        <td style='direction:ltr;font-size:0px;padding:10px 20px;text-align:center;vertical-align:top;'>

                            <div class='dys-column-per-100 outlook-group-fix'
                                style='direction:ltr;display:inline-block;font-size:13px;text-align:left;vertical-align:top;width:100%;'>
                                <table border='0' cellpadding='0' cellspacing='0' role='presentation'
                                    style='vertical-align:top;' width='100%'>
                                    <tr>
                                        <td align='left' style='font-size:0px;padding:10px 25px;word-break:break-word;'>
                                            <div
                                                style='color:#000000;font-family:Helvetica, Arial, sans-serif;font-size:18px;font-weight:light;line-height:28px;text-align:left;'>
                                                Hola se acaba de registrar un nuevo acceso al sistema. los datos de acceso son:
                                                <ul>
                                                    <li>Correo:"+email+@" </li>
                                                    <li>Contraseña: "+psw+@" </li>
                                                </ul>

                                                Para acceder al sistema siga el siguiente <a href='"+ url + @"'> enlace </a>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
                ";

            this.body = head() + cuerpo + foot();
            

        }


        #endregion



        #region funciones base

        private string head()
        {
            return @"

<!doctype html>
<html lang='en' xmlns='http://www.w3.org/1999/xhtml' xmlns:v='urn:schemas-microsoft-com:vml'
    xmlns:o='urn:schemas-microsoft-com:office:office'>

                <head>
    <title>
    </title>
    <meta http-equiv='X-UA-Compatible' content='IE=edge'>
    <meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1'>
    <style type='text/css'>
        #outlook a {
            padding: 0;
        }

        .ReadMsgBody {
            width: 100%;
        }

        .ExternalClass {
            width: 100%;
        }

        .ExternalClass * {
            line-height: 100%;
        }

        body {
            margin: 0;
            padding: 0;
            -webkit-text-size-adjust: 100%;
            -ms-text-size-adjust: 100%;
        }

        table,
        td {
            border-collapse: collapse;
            mso-table-lspace: 0pt;
            mso-table-rspace: 0pt;
        }

        img {
            border: 0;
            height: auto;
            line-height: 100%;
            outline: none;
            text-decoration: none;
            -ms-interpolation-mode: bicubic;
        }

        p {
            display: block;
            margin: 13px 0;
        }
    </style>
    <!--[if !mso]><!-->
    <style type='text/css'>
        @media only screen and (max-width:480px) {
            @-ms-viewport {
                width: 320px;
            }

            @viewport {
                width: 320px;
            }
        }
    </style>
    <!--<![endif]-->
    <!--[if mso]> 
		<xml> 
			<o:OfficeDocumentSettings> 
				<o:AllowPNG/> 
				<o:PixelsPerInch>96</o:PixelsPerInch> 
			</o:OfficeDocumentSettings> 
		</xml>
		<![endif]-->
    <!--[if lte mso 11]> 
		<style type='text/css'> 
			.outlook-group-fix{width:100% !important;}
		</style>
		<![endif]-->
    <style type='text/css'>
        @media only screen and (max-width:480px) {

            table.full-width-mobile {
                width: 100% !important;
            }

            td.full-width-mobile {
                width: auto !important;
            }

        }

        @media only screen and (min-width:480px) {
            .dys-column-per-100 {
                width: 100.000000% !important;
                max-width: 100.000000%;
            }
        }

        @media only screen and (max-width:480px) {

            table.full-width-mobile {
                width: 100% !important;
            }

            td.full-width-mobile {
                width: auto !important;
            }

        }

        @media only screen and (min-width:480px) {
            .dys-column-per-100 {
                width: 100.000000% !important;
                max-width: 100.000000%;
            }
        }

        @media only screen and (min-width:480px) {
            .dys-column-per-100 {
                width: 100.000000% !important;
                max-width: 100.000000%;
            }
        }

        @media only screen and (max-width:480px) {

            table.full-width-mobile {
                width: 100% !important;
            }

            td.full-width-mobile {
                width: auto !important;
            }

        }

        @media only screen and (min-width:480px) {
            .dys-column-per-100 {
                width: 100.000000% !important;
                max-width: 100.000000%;
            }
        }
    </style>
    <!doctype html>
    <html lang='en' xmlns='http://www.w3.org/1999/xhtml' xmlns:v='urn:schemas-microsoft-com:vml'
        xmlns:o='urn:schemas-microsoft-com:office:office'>

    <head>
        <title>
        </title>
        <meta http-equiv='X-UA-Compatible' content='IE=edge'>
        <meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>
        <meta name='viewport' content='width=device-width, initial-scale=1'>
        <style type='text/css'>
            #outlook a {
                padding: 0;
            }

            .ReadMsgBody {
                width: 100%;
            }

            .ExternalClass {
                width: 100%;
            }

            .ExternalClass * {
                line-height: 100%;
            }

            body {
                margin: 0;
                padding: 0;
                -webkit-text-size-adjust: 100%;
                -ms-text-size-adjust: 100%;
            }

            table,
            td {
                border-collapse: collapse;
                mso-table-lspace: 0pt;
                mso-table-rspace: 0pt;
            }

            img {
                border: 0;
                height: auto;
                line-height: 100%;
                outline: none;
                text-decoration: none;
                -ms-interpolation-mode: bicubic;
            }

            p {
                display: block;
                margin: 13px 0;
            }
        </style>
        <!--[if !mso]><!-->
        <style type='text/css'>
            @media only screen and (max-width:480px) {
                @-ms-viewport {
                    width: 320px;
                }

                @viewport {
                    width: 320px;
                }
            }
        </style>
        <!--<![endif]-->
        <!--[if mso]> 
		<xml> 
			<o:OfficeDocumentSettings> 
				<o:AllowPNG/> 
				<o:PixelsPerInch>96</o:PixelsPerInch> 
			</o:OfficeDocumentSettings> 
		</xml>
		<![endif]-->
        <!--[if lte mso 11]> 
		<style type='text/css'> 
			.outlook-group-fix{width:100% !important;}
		</style>
		<![endif]-->
        <style type='text/css'>
            @media only screen and (max-width:480px) {

                table.full-width-mobile {
                    width: 100% !important;
                }

                td.full-width-mobile {
                    width: auto !important;
                }

            }

            @media only screen and (min-width:480px) {
                .dys-column-per-100 {
                    width: 100.000000% !important;
                    max-width: 100.000000%;
                }
            }

            @media only screen and (max-width:480px) {

                table.full-width-mobile {
                    width: 100% !important;
                }

                td.full-width-mobile {
                    width: auto !important;
                }

            }

            @media only screen and (min-width:480px) {
                .dys-column-per-100 {
                    width: 100.000000% !important;
                    max-width: 100.000000%;
                }
            }

            @media only screen and (min-width:480px) {
                .dys-column-per-100 {
                    width: 100.000000% !important;
                    max-width: 100.000000%;
                }
            }

            @media only screen and (max-width:480px) {

                table.full-width-mobile {
                    width: 100% !important;
                }

                td.full-width-mobile {
                    width: auto !important;
                }

            }

            @media only screen and (min-width:480px) {
                .dys-column-per-100 {
                    width: 100.000000% !important;
                    max-width: 100.000000%;
                }
            }
        </style>
        <style type='text/css'>

       
       </style>
    </head>
</head>

<body>
    <div>

        <div style='margin:0px auto;max-width:600px;'>
            <table align='center' border='0' cellpadding='0' cellspacing='0' role='presentation' style='width:100%;'>
                <tbody>
                    <tr>
                        <td style='direction:ltr;font-size:0px;padding:40px;text-align:center;vertical-align:top;'>
                            <!--[if mso | IE]>
<table role='presentation' border='0' cellpadding='0' cellspacing='0'><tr><td style='vertical-align:top;width:600px;'>
<![endif]-->
                            <div class='dys-column-per-100 outlook-group-fix'
                                style='direction:ltr;display:inline-block;font-size:13px;text-align:left;vertical-align:top;width:100%;'>
                                <table border='0' cellpadding='0' cellspacing='0' role='presentation'
                                    style='vertical-align:top;' width='100%'>
                                    <tr>
                                        <td align='left' style='font-size:0px;padding:0px;word-break:break-word;'>
                                            <table border='0' cellpadding='0' cellspacing='0'
                                                style='cellpadding:0;cellspacing:0;color:#000000;font-family:Helvetica, Arial, sans-serif;font-size:13px;line-height:22px;table-layout:auto;width:100%;'
                                                width='100%'>
                                                <tbody>
                                                    <tr>
                                                        <td align='center'>
                                                            <table border='0' cellpadding='0' cellspacing='0'
                                                                role='presentation'
                                                                style='border-collapse:collapse;border-spacing:0px;'>
                                                                <tbody>
                                                                    <tr>
                                                                        <td style='width:250px;'>
                                                                            <img alt='logo'
                                                                                height='auto'
                                                                                src='https://www.granjamar.cl/images/logo.jpg'
                                                                                style='border:none;display:block;font-size:13px;height:auto;outline:none;text-decoration:none;width:100%;'
                                                                                width='250' />
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <!--[if mso | IE]>
</td></tr></table>
<![endif]-->
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>

        <div style='margin:0px auto;max-width:600px;'>
            <table align='center' border='0' cellpadding='0' cellspacing='0' role='presentation' style='width:100%;'>
                <tbody>
                    <tr>
                        <td style='direction:ltr;font-size:0px;padding:20px 0;text-align:center;vertical-align:top;'>

                            <div class='dys-column-per-100 outlook-group-fix'
                                style='direction:ltr;display:inline-block;font-size:13px;text-align:left;vertical-align:top;width:100%;'>
                                <table border='0' cellpadding='0' cellspacing='0' role='presentation'
                                    style='vertical-align:top;' width='100%'>
                                    <tr>
                                        <td align='center'
                                            style='font-size:0px;padding:10px 25px;word-break:break-word;'>
                                            <table border='0' cellpadding='0' cellspacing='0' role='presentation'
                                                style='border-collapse:collapse;border-spacing:0px;'>
                                                <tbody>
                                                    <tr>
                                                        <td style='width:300px;'>
                                                           
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>


";
        }

        private string foot()
        {
            return @"
                    <table align='center' border='0' cellpadding='0' cellspacing='0' role='presentation'
            style='background:#1272BA;background-color:#1272BA;width:100%;'>
            <tbody>
                <tr>
                    <td>
                        <div style='margin:0px auto;max-width:600px;'>
                            <table align='center' border='0' cellpadding='0' cellspacing='0' role='presentation'
                                style='width:100%;'>
                                <tbody>
                                    <tr>
                                        <td
                                            style='direction:ltr;font-size:0px;padding:50px;text-align:center;vertical-align:top;'>
                                            <!--[if mso | IE]>
<table role='presentation' border='0' cellpadding='0' cellspacing='0'><tr><td style='vertical-align:top;width:600px;'>
<![endif]-->
                                            <div class='dys-column-per-100 outlook-group-fix'
                                                style='direction:ltr;display:inline-block;font-size:13px;text-align:left;vertical-align:top;width:100%;'>
                                                <table border='0' cellpadding='0' cellspacing='0' role='presentation'
                                                    style='vertical-align:top;' width='100%'>
                                                    <tr>
                                                        <td align='left'
                                                            style='font-size:0px;padding:0px;word-break:break-word;'>
                                                            <table border='0' cellpadding='0' cellspacing='0'
                                                                style='cellpadding:0;cellspacing:0;color:#000000;font-family:Helvetica, Arial, sans-serif;font-size:13px;line-height:22px;table-layout:auto;width:100%;'
                                                                width='100%'>
                                                                <tr>
                                                                    <td align='left'>
                                                                        <div
                                                                            style='color:#f0f0f0;font-family:Helvetica, Arial, sans-serif;font-size:12px;line-height:28px;text-align:left;'>
                                                                            <p>
                                                                                © Copyright 2022 MarineFarm
                                                                                <br />
                                                                                <a href='"+this.Politica+@"' style='color: #f0f0f0;'>
                                                                                    Politicas de privacidad
                                                                                </a>
                                                                                <br />
                                                                                <a href='"+this.Terminos+@"' style='color: #f0f0f0;'>
                                                                                    Terminos de uso
                                                                                </a>
                                                                            </p>
                                                                        </div>
                                                                    </td>
                                                                    <td align='right'
                                                                        style='vertical-align:top; opacity: 0.35;'
                                                                        width='34px'>
                                                                        <table border='0' cellpadding='0'
                                                                            cellspacing='0' role='presentation'
                                                                            style='border-collapse:collapse;border-spacing:0px;'>
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style='width:30px;'>
                                                                                        <img alt='Facebook'
                                                                                            height='auto'
                                                                                            src='https://assets.opensourceemails.com/imgs/lifestyle/Fct0c2xMRUKPHBdMCcnf_icon-facebook.png'
                                                                                            style='border:none;display:block;font-size:13px;height:auto;outline:none;text-decoration:none;width:100%;'
                                                                                            width='30' />
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                    <td align='right'
                                                                        style='vertical-align:top; opacity: 0.35;'
                                                                        width='34px'>
                                                                        <table border='0' cellpadding='0'
                                                                            cellspacing='0' role='presentation'
                                                                            style='border-collapse:collapse;border-spacing:0px;'>
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style='width:30px;'>
                                                                                        <img alt='Linked In'
                                                                                            height='auto'
                                                                                            src='https://assets.opensourceemails.com/imgs/lifestyle/BHraIlyShi7koHdeMEbD_icon-linkedin.png'
                                                                                            style='border:none;display:block;font-size:13px;height:auto;outline:none;text-decoration:none;width:100%;'
                                                                                            width='30' />
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                    <td align='right'
                                                                        style='vertical-align:top; opacity: 0.35;'
                                                                        width='34px'>
                                                                        <table border='0' cellpadding='0'
                                                                            cellspacing='0' role='presentation'
                                                                            style='border-collapse:collapse;border-spacing:0px;'>
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style='width:30px;'>
                                                                                        <img alt='Twitter' height='auto'
                                                                                            src='https://assets.opensourceemails.com/imgs/lifestyle/Rc7jq7J2ToyH0IGSptTY_icon-twitter.png'
                                                                                            style='border:none;display:block;font-size:13px;height:auto;outline:none;text-decoration:none;width:100%;'
                                                                                            width='30' />
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <!--[if mso | IE]>
</td></tr></table>
<![endif]-->
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</body>
</html>

";
        }
        #endregion

    }
}
