Imports System.IO
Imports System.Xml

Public Class FrmImgCompressionUsingQGIS
    Private Sub BtnCompressImages_Click(sender As Object, e As EventArgs) Handles BtnCompressImages.Click

        Dim configFile As String = "ImgCompressionUsingQGIS_Config.xml"
        Dim inputFilesDir, outputFilesDir, driveLetterOfQGIS, pathOfQGIS As String

        Try

            Dim xmlDoc As New XmlDocument()
            xmlDoc.Load(configFile)

            Dim node As XmlNode = xmlDoc.SelectSingleNode("/config/InputJpegFilesDir")
            inputFilesDir = node.InnerText
            node = xmlDoc.SelectSingleNode("/config/OutputCompressedFilesDir")
            outputFilesDir = node.InnerText
            node = xmlDoc.SelectSingleNode("/config/QGISDriveLetter")
            driveLetterOfQGIS = node.InnerText
            node = xmlDoc.SelectSingleNode("/config/QGISPathExcludingDriveLetter")
            pathOfQGIS = node.InnerText

            'Console.WriteLine(node.InnerText)

            For Each filePath As String In Directory.GetFiles(inputFilesDir, "*.jpg")
                'Console.WriteLine(Path.GetFileName(filePath))
                StartOSGEO4W(filePath, outputFilesDir & "Compressed_" & Path.GetFileName(filePath), driveLetterOfQGIS, pathOfQGIS)
            Next

        Catch ex As Exception
            Writelog("Exception occurred in BtnCompressImages_Click, ex.message: " & ex.Message, "ERR")
            Writelog("Exiting Application", "ERR")
        End Try

        Application.Exit()

    End Sub
End Class
