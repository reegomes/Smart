using RestSharp;
using RestSharp.Authenticators;
using System;
using System.IO;
using System.Web.Http;
using MimeKit;
using System.Net.Mail;

namespace Start.Controllers
{
    public class MailController : ApiController
    {
        [HttpGet]
        public bool EnviaSimplesEmail(string nome, string remetente, string destinatario,string produto)
        {

            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress(remetente);
                message.To.Add(destinatario);
                message.Subject = "Bem-vindo Smart InsureTech";
                message.IsBodyHtml = true;
                message.Body = GetConteudo(nome, produto);

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.UseDefaultCredentials = true;

                smtpClient.Host = "smtp.office365.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new System.Net.NetworkCredential("contato@smart-i.co", "insuretech777");
                smtpClient.Send(message);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        private string GetConteudo(string nome,string produto)
        {
            string html = @"  <!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>
<html xmlns='http://www.w3.org/1999/xhtml'>
   <head>
      <meta http-equiv='Content-Type' content='text/html; charset=utf-8' />
      <meta name='viewport' content='width=device-width, initial-scale=1' />
      <title>Welcome</title>
      <style type='text/css'>
         /* Force Hotmail to display emails at full width */
         .ExternalClass {
         width:100%;
         }
         /* Force Hotmail to display normal line spacing.  More on that: http://www.emailonacid.com/forum/viewthread/43/ */
         .ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div {
         line-height: 100%;
         }
         /* Take care of image borders and formatting */
         img { 
         max-width: 600px; 
         outline: none; 
         text-decoration: none; 
         -ms-interpolation-mode: bicubic;
         margin:0;
         padding:0;
         display: block;
         }
         a img { border: none; }
         table { border-collapse: collapse !important; }
         #outlook a { padding:0; }
         .ReadMsgBody { width: 100%; }
         .ExternalClass {width:100%;}
         .backgroundTable {margin:0 auto; padding:0; width:100% !important;}
         table td {border-collapse: collapse;}
         .ExternalClass * {line-height: 115%;}
         /* General styling */
         td {
         font-family: Arial, sans-serif;
         }
         body {
         -webkit-font-smoothing:antialiased;
         -webkit-text-size-adjust:none;
         width: 100%;
         height: 100%;
         color: #6b7d90;2
         font-weight: 400;
         font-size: 18px;
         }
         h1 {
         margin: 10px 0;
         }
         a {
         color: #4baad4;
         text-decoration: underline;
         }
         .desktop-hide {
         display: none;
         }
         .hero-bg {
         background: -webkit-linear-gradient(90deg, #2991bf 0%,#7ecaec 100%);
         background-color: #4baad4;
         }
         .force-full-width {
         width: 100% !important;
         }
         .body-padding {
         padding: 0 75px;
         }
         .force-width-80 {
         width: 80% !important;
         }
      </style>
      <style type='text/css' media='screen'>
         @media screen {
         /* Thanks Outlook 2013! http://goo.gl/XLxpyl */
         * {
         font-family:'Arial', 'sans-serif' !important;
         }
         .w280 {
         width: 280px !important;
         }
         }
      </style>
      <style type='text/css' media='only screen and (max-width: 480px)'>
         /* Mobile styles */
         @media only screen and (max-width: 480px) {
         table[class*='w320'] {
         width: 320px !important;
         }
         td[class*='w320'] {
         width: 280px !important;
         padding-left: 20px !important;
         padding-right: 20px !important;
         }
         img[class*='w320'] {
         height: 40px !important;
         }
         td[class*='mobile-spacing'] {
         padding-top: 10px !important;
         padding-bottom: 10px !important;
         }
         *[class*='mobile-hide'] {
         display: none !important;
         }
         .desktop-hide {
         display: block!important;
         }
         *[class*='mobile-br'] {
         font-size: 12px !important;
         }
         td[class*='mobile-w20'] {
         width: 20px !important;
         }
         img[class*='mobile-w20'] {
         width: 20px !important;
         }
         td[class*='mobile-center'] {
         text-align: center !important;
         }
         table[class*='w100p'] {
         width: 100% !important;
         }
         td[class*='activate-now'] {
         padding-right: 0 !important;
         padding-top: 20px !important;
         }
         td[class*='mobile-resize'] {
         font-size: 22px !important;
         padding-left: 15px !important;
         }
         td[class*='mobile-hide'] {
         display:none;
         }
         }
      </style>
   </head>
   <body  offset='0' class='body externalClass' style='padding:0; margin:0; display:block; background:#e8ecf0; -webkit-text-size-adjust:none' bgcolor='#e8ecf0'>
      <table align='center' cellpadding='0' cellspacing='0' width='100%' height='100%'>
         <tr>
            <td align='center' valign='top' style='background-color:#eeebeb' width='100%'>
               <center>
                  <table cellspacing='0' cellpadding='0' width='600' class='w320'>
                     <tr>
                        <td align='center' valign='top'>
                           <table class='mobile-hide' style='margin:0 auto;' cellspacing='0' cellpadding='0' width='100%'>
                              <tr>
                                 <td height='25' style='font-size: 25px; line-height: 25px;'>&nbsp;</td>
                              </tr>
                              <tr>
                                 <td align='center'>
                                    <img  height='auto' src='https://www.smart-i.co/wp-content/uploads/2019/07/logo-smart.png' alt='Smart InsureTech' ></a>
                                 </td>
                                 <td align='right' style='color: #4baad4; font-size: 18px;' class='mobile-hide'>
                                    <div>
                                       
                                    </div>
                                 </td>
                              </tr>
                              <tr>
                                 <td height='25' style='font-size: 25px; line-height: 25px;'>&nbsp;</td>
                              </tr>
                           </table>
                           <table cellspacing='0' cellpadding='0' width='100%'>
                              <tr>
                                 <td class='hero-bg'>
                                    <table cellspacing='0' cellpadding='0' width='100%'>
                                       <tr>
                                          <td height='45' style='font-size: 45px; line-height: 45px;' class='desktop-hide'>&nbsp;</td>
                                       </tr>
                                       <tr>
                                          <td style='font-size:40px; font-weight: 400; color: #ffffff; text-align:center;'>
                                             <!--<img src='https://www.smart-i.co/wp-content/uploads/2019/07/logo-smart.png' class='desktop-hide' height='40' style='margin: 0 auto;'/>-->
                                             <div class='mobile-br'>&nbsp;</div>
                                             Parabéns!
                                             <br>
                                             {{NAME}}
                                             
                                             
                                          </td>
                                       </tr>
                                       <tr>
                                          <td height='15' style='font-size: 15px; line-height: 15px;'>&nbsp;</td>
                                       </tr>
                                       <tr>
                                          <td style='font-size:24px; text-align:center; padding: 0 75px; color:#ffffff;'>
                                             Agora você está protegido pela Smart InsureTech!
                                             <br>
                                             Você escolheu o produto {{PRODUCT_NAME}}
                                          </td>
                                       </tr>
                                       <tr>
                                          <td height='50' style='font-size: 50px; line-height: 50px;'>&nbsp;</td>
                                       </tr>
                                    </table>
                                    <table cellspacing='0' cellpadding='0' width='100%'>
                                       <tr>
                                          <td>
                                             <img align='center' src='https://www.smart-i.co/wp-content/uploads/2019/07/img-quem-somos.png' />
                                          </td>
                                       </tr>
                                    </table>
                                 </td>
                              </tr>
                           </table>
                           <table cellspacing='0' cellpadding='0' class='force-full-width' bgcolor='#ffffff' >
                              <tr>
                                 <td style='background-color:#ffffff;'>
                                    <br>
                                    <center>
                                       <table style='margin: 0 auto;' cellspacing='0' cellpadding='0' class='force-width-80'>
                                          <tr>
                                             <td align='left' valign='top' style='color: #7f8c8d; font-size: 20px; font-weight: 700; line-height: 24px;'>
                                                <img src='https://www.smart-i.co/wp-content/uploads/2019/08/compra-finalizada.png' alt=''>
                                             </td>
                                             <td width='40'>&nbsp;</td>
                                             <td align='left' style='color: #95a5a6; font-size: 15px; font-weight: 500; line-height: 24px;'>
                                                <div style='line-height: 24px'>
                                                   <strong style='color: #4baad4; font-weight: 700;'>Sua compra foi finalizada!</strong><br>Neste e-mail você encontra os telefones para contato, o bilhete apólice e as respectivas condições gerais.<br> Para sua garantia e plena validade do Bilhete Apólice, conserve-o até o final da vigência.
                                                </div>
                                             </td>
                                          </tr>
                                          <tr>
                                            <td height='35' style='font-size: 35px; line-height: 35px;'>&nbsp;</td>
                                          </tr>
                                          <tr>
                                             <td align='left' valign='top' style='color: #7f8c8d; font-size: 20px; font-weight: 700; line-height: 24px;'>
                                                <img src='https://www.smart-i.co/wp-content/uploads/2019/08/Emergência.png' alt=''>
                                             </td>
                                             <td width='40'>&nbsp;</td>
                                             <td align='left' style='color: #95a5a6; font-size: 15px; font-weight: 500; line-height: 24px;'>
                                                <div style='line-height: 24px'>
                                                   <strong style='color: #4baad4; font-weight: 700;'>Emergências:</strong><br>Caso ocorra alguma emergência ligue no número <a style='color: #2991bf ' href='tel:+55 11 999999999'>(11) 0800-xx-xxxx</a>
                                                </div>
                                             </td>
                                          </tr>
                                          <tr>
                                            <td height='35' style='font-size: 35px; line-height: 35px;'>&nbsp;</td>
                                          </tr>
                                          <tr>
                                             <td align='left' valign='top' style='color: #7f8c8d; font-size: 20px; font-weight: 700; line-height: 24px;'>
                                                <img src='https://www.smart-i.co/wp-content/uploads/2019/08/SAC2.png' alt=''>
                                             </td>
                                             <td width='40'>&nbsp;</td>
                                             <td align='left' style='color: #95a5a6; font-size: 15px; font-weight: 500; line-height: 24px;'>
                                                <div style='line-height: 24px'>
                                                   <strong style='color: #4baad4; font-weight: 700;'>SAC (Informações, solicitações, reclamações, sinistros):</strong><br> Caso venha a ter alguma dúvida, reclamação, solicitação ou sinistros entre em contato com a gente no número <a style='color: #2991bf ' href='tel:+55 11 999999999'>(11) 0800-xx-xxxx</a>
                                                </div>
                                             </td>
                                          </tr>
                                          <tr>
                                            <td height='35' style='font-size: 35px; line-height: 35px;'>&nbsp;</td>
                                          </tr>
                                          <tr>
                                             <td align='left' valign='top' style='color: #7f8c8d; font-size: 20px; font-weight: 700; line-height: 24px;'>
                                                <img src='https://www.smart-i.co/wp-content/uploads/2019/08/Ouvidoria.png' alt=''>
                                             </td>
                                             <td width='40'>&nbsp;</td>
                                             <td align='left' style='color: #95a5a6; font-size: 15px; font-weight: 500; line-height: 24px;'>
                                                <div style='line-height: 24px'>
                                                   <strong style='color: #4baad4; font-weight: 700;'>Ouvidoria</strong><br>Para entrar em contato com a nossa Ouvidoria ligue no número <a style='color: #2991bf ' href='tel:+55 11 999999999'>(11) 0800-xx-xxxx</a> ou mande um e-mail para <a style='color: #2991bf ' href='mailto:contato@smart-i.co'>contato@smart-i.co</a>
                                                </div>
                                             </td>
                                          </tr>
                                       </table>
                                    </center>
                                    <table style='margin:0 auto;' cellspacing='0' cellpadding='10' width='100%'>
                                       <tr>
                                          <td style='text-align:center; margin:0 auto;'>
                                             <br>
                                             <table width='100%' border='0' cellspacing='0' cellpadding='0' align='center'>
                                                <tr>
                                                   <td>
                                                      <div>
                                                         
                                                         <a href='https://www.jjire.com.br/smart/apolice/index.php?napolice=255255&ok=ok' style='background-color:#ff6f00;border:1px solid #ff6f00;color:#ffffff;display:inline-block;font-family:sans-serif;font-size:18px;line-height:24px;text-align:center;text-decoration:none;width:300px;border-radius:6px;'>Clique aqui para visualizar ou imprimir seu Bilhete Apólice</a>
                                                      </div>
                                                   </td>
                                                </tr>
                                             </table>
                                             <br>
                                          </td>
                                       </tr>
                                    </table>
                                    <table border='0' align='center' cellpadding='0' cellspacing='0' bgcolor='ffffff' class='force-full-width'>
                                       <tr>
                                          <td align='center'>     
                                       <tr>
                                          <td height='10' style='font-size: 10px; line-height: 10px;'>&nbsp;</td>
                                       </tr>
                                       <tr>
                                          <td align='center'>      
                                             <img src='https://s3.amazonaws.com/appcues-email-assets/images/wave-inverse.png' style='display: block; width: 100%' width='100%' border='0' alt=''/>
                                          </td>
                                       </tr>
                                       </td>      
                                       </tr>      
                                    </table>
                                    <table border='0' width='100%' cellpadding='0' cellspacing='0' bgcolor='4baad4'>
                                       <tr>
                                          <td align='center'>
                                             <table border='0' align='center' width='590' cellpadding='0' cellspacing='0' bgcolor='4baad4'>
                                                <tr>
                                                <tr>
                                                   <td height='45' style='font-size: 45px; line-height: 45px;'>&nbsp;</td>
                                                </tr>
                                                <td align='center'>
                                                   <table border='0' align='center' width='590' cellpadding='0' cellspacing='0' bgcolor='4baad4'>
                                                      <tr>
                                                         <td align='center'>        
                                                      <tr>
                                                         <td align='center'>
                                                           <p style='color: white'>Smart InsureTech. Todos os direitos reservados.</p>
                                                         </td>
                                                      </tr>
                                                      </td>
                                                      </tr>
                                                   </table>
                                                </td>
                                                </tr>
                                                <tr>
                                                   <td height='65' style='font-size: 65px; line-height: 65px;'>&nbsp;</td>
                                                </tr>
                                             </table>
                                          </td>
                                       </tr>
                                    </table>
                                    <table cellspacing='0' cellpadding='0' bgcolor='#e8ecf0'  class='force-full-width'>
                                       
                                       <tr>
                                          <td style='color:#27aa90; font-size: 14px; text-align:center;'>
                                             <a href='{% unsubscribe_url %}' class='untracked'>Unsubscribe</a>
                                          </td>
                                       </tr>
                                       <tr>
                                          <td style='font-size:12px;'>&nbsp;</td>
                                       </tr>
                                    </table>
                                 </td>
                              </tr>
                           </table>
                        </td>
                     </tr>
                  </table>
               </center>
            </td>
         </tr>
      </table>
   </body>
</html>




";

            var neewHtml = html.Replace("{{NAME}}", nome).ToString().Replace("{{PRODUCT_NAME}}",produto);
            return neewHtml;
        }
    }

    public class Email
    {
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
    }
}
