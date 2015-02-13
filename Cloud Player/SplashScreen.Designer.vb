<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SplashScreen
    Inherits Zumwani.CommonLibrary.Templates.Window

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SplashScreen))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PanoramaTabControl1 = New Zumwani.CommonLibrary.Controls.PanoramaTabControl()
        Me.ErrorTab = New System.Windows.Forms.TabPage()
        Me.ErrorOKButton = New Zumwani.CommonLibrary.Controls.MetroButton()
        Me.ErrorMessageLabel = New System.Windows.Forms.Label()
        Me.ErrorDeleteButton = New Zumwani.CommonLibrary.Controls.MetroButton()
        Me.ErrorIgnoreButton = New Zumwani.CommonLibrary.Controls.MetroButton()
        Me.UpgradeTab = New System.Windows.Forms.TabPage()
        Me.UpgradeMessageLabel = New System.Windows.Forms.Label()
        Me.UpgradeDeleteButton = New Zumwani.CommonLibrary.Controls.MetroButton()
        Me.UpgradeIgnoreButton = New Zumwani.CommonLibrary.Controls.MetroButton()
        Me.UpgradeUpgradeButton = New Zumwani.CommonLibrary.Controls.MetroButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.LoadingLabel = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.DotTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.PanoramaTabControl1.SuspendLayout()
        Me.ErrorTab.SuspendLayout()
        Me.UpgradeTab.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.Panel1.Controls.Add(Me.PanoramaTabControl1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.ProgressBar1)
        Me.Panel1.Controls.Add(Me.LoadingLabel)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'PanoramaTabControl1
        '
        Me.PanoramaTabControl1.AnimationDirection = Zumwani.CommonLibrary.Controls.PanoramaTabControl.AnimationDirections.Horizontal
        Me.PanoramaTabControl1.AnimationType = Zumwani.CommonLibrary.Controls.PanoramaTabControl.AnimationTypes.None
        Me.PanoramaTabControl1.Controls.Add(Me.ErrorTab)
        Me.PanoramaTabControl1.Controls.Add(Me.UpgradeTab)
        Me.PanoramaTabControl1.DisplayTabs = Zumwani.CommonLibrary.Controls.PanoramaTabControl.DisplayTabsEnum.OnlyInDesignMode
        resources.ApplyResources(Me.PanoramaTabControl1, "PanoramaTabControl1")
        Me.PanoramaTabControl1.Name = "PanoramaTabControl1"
        Me.PanoramaTabControl1.SelectedIndex = 0
        Me.PanoramaTabControl1.Speed = 9
        '
        'ErrorTab
        '
        Me.ErrorTab.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.ErrorTab.Controls.Add(Me.ErrorOKButton)
        Me.ErrorTab.Controls.Add(Me.ErrorMessageLabel)
        Me.ErrorTab.Controls.Add(Me.ErrorDeleteButton)
        Me.ErrorTab.Controls.Add(Me.ErrorIgnoreButton)
        resources.ApplyResources(Me.ErrorTab, "ErrorTab")
        Me.ErrorTab.Name = "ErrorTab"
        '
        'ErrorOKButton
        '
        resources.ApplyResources(Me.ErrorOKButton, "ErrorOKButton")
        Me.ErrorOKButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.ErrorOKButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.ErrorOKButton.FlatAppearance.BorderSize = 0
        Me.ErrorOKButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.ErrorOKButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.ErrorOKButton.Name = "ErrorOKButton"
        Me.ErrorOKButton.UseVisualStyleBackColor = False
        '
        'ErrorMessageLabel
        '
        resources.ApplyResources(Me.ErrorMessageLabel, "ErrorMessageLabel")
        Me.ErrorMessageLabel.Name = "ErrorMessageLabel"
        '
        'ErrorDeleteButton
        '
        resources.ApplyResources(Me.ErrorDeleteButton, "ErrorDeleteButton")
        Me.ErrorDeleteButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.ErrorDeleteButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.ErrorDeleteButton.FlatAppearance.BorderSize = 0
        Me.ErrorDeleteButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.ErrorDeleteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.ErrorDeleteButton.Name = "ErrorDeleteButton"
        Me.ErrorDeleteButton.UseVisualStyleBackColor = True
        '
        'ErrorIgnoreButton
        '
        resources.ApplyResources(Me.ErrorIgnoreButton, "ErrorIgnoreButton")
        Me.ErrorIgnoreButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.ErrorIgnoreButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.ErrorIgnoreButton.FlatAppearance.BorderSize = 0
        Me.ErrorIgnoreButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.ErrorIgnoreButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.ErrorIgnoreButton.Name = "ErrorIgnoreButton"
        Me.ErrorIgnoreButton.UseVisualStyleBackColor = True
        '
        'UpgradeTab
        '
        Me.UpgradeTab.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.UpgradeTab.Controls.Add(Me.UpgradeMessageLabel)
        Me.UpgradeTab.Controls.Add(Me.UpgradeDeleteButton)
        Me.UpgradeTab.Controls.Add(Me.UpgradeIgnoreButton)
        Me.UpgradeTab.Controls.Add(Me.UpgradeUpgradeButton)
        resources.ApplyResources(Me.UpgradeTab, "UpgradeTab")
        Me.UpgradeTab.Name = "UpgradeTab"
        '
        'UpgradeMessageLabel
        '
        resources.ApplyResources(Me.UpgradeMessageLabel, "UpgradeMessageLabel")
        Me.UpgradeMessageLabel.Name = "UpgradeMessageLabel"
        '
        'UpgradeDeleteButton
        '
        resources.ApplyResources(Me.UpgradeDeleteButton, "UpgradeDeleteButton")
        Me.UpgradeDeleteButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.UpgradeDeleteButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.UpgradeDeleteButton.FlatAppearance.BorderSize = 0
        Me.UpgradeDeleteButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.UpgradeDeleteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.UpgradeDeleteButton.Name = "UpgradeDeleteButton"
        Me.UpgradeDeleteButton.UseVisualStyleBackColor = False
        '
        'UpgradeIgnoreButton
        '
        resources.ApplyResources(Me.UpgradeIgnoreButton, "UpgradeIgnoreButton")
        Me.UpgradeIgnoreButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.UpgradeIgnoreButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.UpgradeIgnoreButton.FlatAppearance.BorderSize = 0
        Me.UpgradeIgnoreButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.UpgradeIgnoreButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.UpgradeIgnoreButton.Name = "UpgradeIgnoreButton"
        Me.UpgradeIgnoreButton.UseVisualStyleBackColor = False
        '
        'UpgradeUpgradeButton
        '
        resources.ApplyResources(Me.UpgradeUpgradeButton, "UpgradeUpgradeButton")
        Me.UpgradeUpgradeButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.UpgradeUpgradeButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.UpgradeUpgradeButton.FlatAppearance.BorderSize = 0
        Me.UpgradeUpgradeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.UpgradeUpgradeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.UpgradeUpgradeButton.Name = "UpgradeUpgradeButton"
        Me.UpgradeUpgradeButton.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        resources.ApplyResources(Me.Panel2, "Panel2")
        Me.Panel2.Name = "Panel2"
        '
        'ProgressBar1
        '
        resources.ApplyResources(Me.ProgressBar1, "ProgressBar1")
        Me.ProgressBar1.Name = "ProgressBar1"
        '
        'LoadingLabel
        '
        resources.ApplyResources(Me.LoadingLabel, "LoadingLabel")
        Me.LoadingLabel.Name = "LoadingLabel"
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        '
        'DotTimer
        '
        Me.DotTimer.Enabled = True
        Me.DotTimer.Interval = 750
        '
        'SplashScreen
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SplashScreen"
        Me.Panel1.ResumeLayout(False)
        Me.PanoramaTabControl1.ResumeLayout(False)
        Me.ErrorTab.ResumeLayout(False)
        Me.UpgradeTab.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LoadingLabel As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents DotTimer As System.Windows.Forms.Timer
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PanoramaTabControl1 As Zumwani.CommonLibrary.Controls.PanoramaTabControl
    Friend WithEvents ErrorTab As System.Windows.Forms.TabPage
    Friend WithEvents UpgradeTab As System.Windows.Forms.TabPage
    Friend WithEvents UpgradeMessageLabel As System.Windows.Forms.Label
    Friend WithEvents UpgradeDeleteButton As Zumwani.CommonLibrary.Controls.MetroButton
    Friend WithEvents UpgradeIgnoreButton As Zumwani.CommonLibrary.Controls.MetroButton
    Friend WithEvents UpgradeUpgradeButton As Zumwani.CommonLibrary.Controls.MetroButton
    Friend WithEvents ErrorOKButton As Zumwani.CommonLibrary.Controls.MetroButton
    Friend WithEvents ErrorMessageLabel As System.Windows.Forms.Label
    Friend WithEvents ErrorDeleteButton As Zumwani.CommonLibrary.Controls.MetroButton
    Friend WithEvents ErrorIgnoreButton As Zumwani.CommonLibrary.Controls.MetroButton
    Public WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
