namespace DeleteFiles
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.deleteFilesProcessor = new System.ServiceProcess.ServiceProcessInstaller();
            this.deleteFiles = new System.ServiceProcess.ServiceInstaller();
            // 
            // deleteFilesProcessor
            // 
            this.deleteFilesProcessor.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.deleteFilesProcessor.Password = null;
            this.deleteFilesProcessor.Username = null;
            // 
            // deleteFiles
            // 
            this.deleteFiles.ServiceName = "DeleteFiles";
            this.deleteFiles.Description = "Delete Files Service Demo";
            this.deleteFiles.ServiceName = "DeleteFiles";
            
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.deleteFilesProcessor,
            this.deleteFiles});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller deleteFilesProcessor;
        private System.ServiceProcess.ServiceInstaller deleteFiles;
    }
}