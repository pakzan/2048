<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container
        Me.label1 = New System.Windows.Forms.Label
        Me.timerup = New System.Windows.Forms.Timer(Me.components)
        Me.Timerdown = New System.Windows.Forms.Timer(Me.components)
        Me.Timerleft = New System.Windows.Forms.Timer(Me.components)
        Me.Timerright = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(84, 13)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(0, 20)
        Me.label1.TabIndex = 0
        '
        'timerup
        '
        Me.timerup.Interval = 10
        '
        'Timerdown
        '
        Me.Timerdown.Interval = 10
        '
        'Timerleft
        '
        Me.Timerleft.Interval = 10
        '
        'Timerright
        '
        Me.Timerright.Interval = 10
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(411, 364)
        Me.Controls.Add(Me.label1)
        Me.Name = "Form1"
        Me.Text = "2048"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents timerup As System.Windows.Forms.Timer
    Friend WithEvents Timerdown As System.Windows.Forms.Timer
    Friend WithEvents Timerleft As System.Windows.Forms.Timer
    Friend WithEvents Timerright As System.Windows.Forms.Timer

End Class
