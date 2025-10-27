Public Class Encapsulation
    Private Sub Encapsulation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.ReadOnly = True
        TextBox1.Multiline = True
        TextBox1.Text = "Encapsulation bundles data and methods and restricts direct access." & vbCrLf &
                        "Example: BankAccount exposes Deposit/Withdraw/GetBalance while keeping the balance field private." & vbCrLf & vbCrLf &
                        "Click the button to run the demo and append results below."
    End Sub


    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        ' Simple encapsulation example when button is clicked
        Dim account As New BankAccount
        account.Deposit(1000)
        account.Deposit(500)

        Dim currentBalance = account.GetBalance
        TextBox1.AppendText(Environment.NewLine & "--- Encapsulation Demo ---" & Environment.NewLine)
        TextBox1.AppendText("Deposited 1000, then 500." & Environment.NewLine)
        TextBox1.AppendText($"Account Balance: ${currentBalance}" & Environment.NewLine)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox1.ReadOnly = True
    End Sub

    Private Sub OutlinedLabel1_Click(sender As Object, e As EventArgs) Handles OutlinedLabel1.Click

    End Sub
End Class

Public Class BankAccount
    Private balance As Decimal ' Private field - encapsulated

    Public Sub Deposit(amount As Decimal)
        If amount > 0 Then
            balance += amount
        End If
    End Sub

    Public Sub Withdraw(amount As Decimal)
        If amount > 0 AndAlso amount <= balance Then
            balance -= amount
        End If
    End Sub

    Public Function GetBalance() As Decimal
        Return balance
    End Function

    ' Property example (alternative way to access private data)
    Public ReadOnly Property CurrentBalance As Decimal
        Get
            Return balance
        End Get
    End Property
End Class