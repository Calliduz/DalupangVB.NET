Imports System
Imports System.Globalization
Imports System.Windows.Forms

Public Class FormRelationalOperators
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub FormRelationalOperators_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtExample.Text =
"Relational operators compare two values and return True or False.
Examples:
  >   : greater than
  <   : less than
  >=  : greater than or equal
  <=  : less than or equal
  =   : equal
  <>  : not equal

Type two values and click Evaluate. Numeric inputs are compared numerically; otherwise comparisons are lexical (string)."
    End Sub

    Private Sub btnEvaluate_Click(sender As Object, e As EventArgs)
        lstResults.Items.Clear()

        Dim s1 As String = txtValue1.Text.Trim()
        Dim s2 As String = txtValue2.Text.Trim()

        Dim n1 As Double
        Dim n2 As Double
        Dim bothNumbers As Boolean = Double.TryParse(s1, NumberStyles.Any, CultureInfo.CurrentCulture, n1) AndAlso Double.TryParse(s2, NumberStyles.Any, CultureInfo.CurrentCulture, n2)

        If bothNumbers Then
            lstResults.Items.Add(String.Format("Numeric comparison: {0} and {1}", n1, n2))
            lstResults.Items.Add(String.Format("{0} >  {1}  -> {2}", n1, n2, (n1 > n2).ToString()))
            lstResults.Items.Add(String.Format("{0} <  {1}  -> {2}", n1, n2, (n1 < n2).ToString()))
            lstResults.Items.Add(String.Format("{0} >= {1}  -> {2}", n1, n2, (n1 >= n2).ToString()))
            lstResults.Items.Add(String.Format("{0} <= {1}  -> {2}", n1, n2, (n1 <= n2).ToString()))
            lstResults.Items.Add(String.Format("{0} =  {1}  -> {2}", n1, n2, (n1 = n2).ToString()))
            lstResults.Items.Add(String.Format("{0} <> {1}  -> {2}", n1, n2, (n1 <> n2).ToString()))
        Else
            lstResults.Items.Add(String.Format("String comparison (lexical): ""{0}"" and ""{1}""", s1, s2))
            lstResults.Items.Add(String.Format("""{0}"" >  ""{1}""  -> {2}", s1, s2, (s1 > s2).ToString()))
            lstResults.Items.Add(String.Format("""{0}"" <  ""{1}""  -> {2}", s1, s2, (s1 < s2).ToString()))
            lstResults.Items.Add(String.Format("""{0}"" >= ""{1}""  -> {2}", s1, s2, (s1 >= s2).ToString()))
            lstResults.Items.Add(String.Format("""{0}"" <= ""{1}""  -> {2}", s1, s2, (s1 <= s2).ToString()))
            lstResults.Items.Add(String.Format("""{0}"" =  ""{1}""  -> {2}", s1, s2, (s1 = s2).ToString()))
            lstResults.Items.Add(String.Format("""{0}"" <> ""{1}""  -> {2}", s1, s2, (s1 <> s2).ToString()))
            Dim cmp = String.Compare(s1, s2, StringComparison.CurrentCulture)
            lstResults.Items.Add(String.Format("String.Compare -> {0} (negative: first < second, 0: equal, positive: first > second)", cmp))
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub btnExampleClear_Click(sender As Object, e As EventArgs)
        lstResults.Items.Clear()
    End Sub
End Class