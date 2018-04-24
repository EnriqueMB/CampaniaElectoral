using DllCampElectoral.Global;
using Google.Authenticator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampaniaElectoral
{
    public partial class frmEjemplo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!HttpContext.Current.User.Identity.IsAuthenticated)
            //{
            //    Response.Redirect("Login.aspx");
            //}

            //Se enviará al correo para que lo puedan agregar a google app
            //string qrCodeImageUrl = setupInfo.QrCodeSetupImageUrl;
            //string manualEntrySetupCode = setupInfo.ManualEntryKey;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("frmLogin2.aspx"); 
            //TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
            //bool isCorrectPIN = false;//tfa.ValidateTwoFactorPIN("MiPassHere", this.TextBox1.Text);
            //isCorrectPIN = this.TextBox1.Text == tfa.GetCurrentPIN("");
            //if(isCorrectPIN)
            //{
            //    this.Label1.Text = "Pin válido";
            //}
            //else
            //{
            //    this.Label1.Text = "Pin Inválido";
            ////}
        }

        public bool ValidateTwoFactorPIN(string userID, string userPIN)
        {
            try
            {
                TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
                bool isCorrectPIN = userPIN == tfa.GetCurrentPIN(userID);
                return isCorrectPIN;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public SetupCode GenerateSetupCodeApp(string mail, string userID)
        {
            try
            {
                TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
                var setupInfo = tfa.GenerateSetupCode(Comun.NameApp, mail, userID, 300, 300);
                return setupInfo;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}