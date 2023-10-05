<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImgCompressionUsingQGIS
    Inherits System.Windows.Forms.Form

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
        Me.BtnCompressImages = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BtnCompressImages
        '
        Me.BtnCompressImages.Location = New System.Drawing.Point(334, 185)
        Me.BtnCompressImages.Name = "BtnCompressImages"
        Me.BtnCompressImages.Size = New System.Drawing.Size(111, 45)
        Me.BtnCompressImages.TabIndex = 0
        Me.BtnCompressImages.Text = "Compress Images"
        Me.BtnCompressImages.UseVisualStyleBackColor = True
        '
        'FrmImgCompressionUsingQGIS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.BtnCompressImages)
        Me.Name = "FrmImgCompressionUsingQGIS"
        Me.Text = "Image Compression using QGIS"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnCompressImages As Button
End Class
