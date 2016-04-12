Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WebBrowser1.ScriptErrorsSuppressed = True


    End Sub

    Sub paro()
        Dim kadi = ListBox1.SelectedItem.ToString()
        WebBrowser1.Document.GetElementById("txtImei").SetAttribute("Value", kadi)

        Dim alelemnt As HtmlElementCollection = WebBrowser1.Document.All

        For Each webpagel As HtmlElement In alelemnt
            If webpagel.GetAttribute("value") = "Sorgula" Then
                webpagel.InvokeMember("click")
            End If
        Next

    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted


      




        If WebBrowser1.Url.ToString = "https://www.turkiye.gov.tr/imei-sorgulama" Then

            Dim i = Val(Label2.Text)
            ListBox1.SetSelected(i, True)
            Label2.Text = i + 1

        

            Call paro()
            
            ToolStripProgressBar1.Value += 1
        ElseIf WebBrowser1.Url.ToString = "https://www.turkiye.gov.tr/imei-sorgulama?submit" Then
            Dim all_code = WebBrowser1.Document.Body.InnerHtml

            Dim kadi = ListBox1.SelectedItem.ToString()
            Dim xas = InStr(all_code, "IMEI NUMARASI KAYITLI")
            If xas > 0 Then
                Label1.Text = " Ime Kayıtlı"
                TextBox5.Text = TextBox5.Text + kadi + vbNewLine
                Label1.Text = kadi + "        " + Label1.Text
                ListBox2.Items.Add(Label1.Text)
            Else

            End If


            RichTextBox2.Text = Label1.Text

            WebBrowser1.Navigate("https://www.turkiye.gov.tr/imei-sorgulama")
      
        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        

        If Clipboard.GetDataObject.GetDataPresent(DataFormats.Text) And TextBox4.Text = "" Then
            Me.TextBox4.Paste()
        End If
        If TextBox4.Text = "" Then Exit Sub

      
       



        Dim strComputer, arrComputers() As String
        arrComputers = TextBox4.Text.Split(Environment.NewLine)

        Dim i As Integer = 0
        For i = LBound(arrComputers) To UBound(arrComputers)
            strComputer = Trim(arrComputers(i))


            Dim index As Integer = ListBox1.FindString(strComputer)

            If index <> -1 Then
                ListBox1.SetSelected(index, True)
            Else
                ListBox1.Items.Add(strComputer)
            End If







        Next


        ToolStripProgressBar1.Maximum = Val(ListBox1.Items.Count()) - 1

        WebBrowser1.Navigate("https://www.turkiye.gov.tr/imei-sorgulama")
        TextBox4.Text = ""

    End Sub
    Private WithEvents doc As HtmlDocument

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
     
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
       

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim alelemnt As HtmlElementCollection = WebBrowser1.Document.All

        For Each webpagel As HtmlElement In alelemnt
            If webpagel.GetAttribute("value") = "Sorgula" Then
                webpagel.InvokeMember("click")
            End If
Next

    End Sub

    Private Sub Kopyala_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles sagci.Opening

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Try
            If ListBox2.SelectedItem <> "" Then
                Dim s = Replace(ListBox2.SelectedItem.ToString, "Ime Kayıtlı", "")
                s = Replace(s, " ", "")
                Clipboard.SetText(s)
            End If
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        SaveFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        Dim dosya As String
        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            dosya = SaveFileDialog1.FileName()
            Dim dn3
            dn3 = FreeFile()
            FileOpen(dn3, dosya, OpenMode.Append)
            Print(dn3, TextBox5.Text)
            FileClose(dn3)
            MsgBox("Veri başarıyla Kaydedildi", vbInformation, "Bilgi")
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim i = 0
        Dim se = Val(ComboBox1.SelectedItem)
        If Val(se) < 9 Then
            se = "10"
        End If
        Do
            If i = se Then Exit Do

            Dim s = Val(Rnd(16))
            s = Replace(s, ",", "")
            If Val(s) > 100000000000000 Then
                TextBox4.Text = TextBox4.Text + CStr(s) + vbNewLine
                i += 1
            End If

        Loop
       

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim metin = "* Rastgele sayı üretirken yüksek rakamda pcniz donabilir" + vbNewLine + "* Aynı rakamı tekrar eklerseniz sistem görmezden gelicektir tekrar bulunan imeler arasına atmaz." + vbNewLine + "* Numara ekleyi elle yapabilirsiniz veya direk bir yerden ALT ALTA olan bir listeleyi kopyalayın ardındanda Numaraları ekle butonuna basın" + vbNewLine + "* Kayıtlı olarak bulunan imelere sağ tıklayarak kopyalaya bilirsiniz."
        MsgBox(metin, MsgBoxStyle.Information, "Yardım")
    End Sub
End Class
