Imports System.IO

Module ModGlobal

    Public gobjFS As FileStream
    Public gLogFileName As String = "Log_ImgCompressionUsingQGIS.TXT"

    'OSGEO4W - Open Source Geospatial for Windows
    '
    Public Sub StartOSGEO4W(ByVal pInputFile As String, ByVal pOutputFile As String, ByVal pDriveLetterOfQGIS As String, ByVal pPathOfQGIS As String)

        Dim cmd As String

        Try
            Writelog("Beginning compression of: " & pInputFile, "INF")
            cmd = "/c CompressUsingQGIS.BAT " &
                pDriveLetterOfQGIS & " " &
                Chr(34) & pPathOfQGIS & Chr(34) & " " &
                Chr(34) & pInputFile & Chr(34) & " " &
                Chr(34) & pOutputFile & Chr(34)

            Dim startInfo As New ProcessStartInfo With {
                .FileName = "cmd.exe",
                .Arguments = cmd,
                .UseShellExecute = False,
                .RedirectStandardOutput = True,
                .RedirectStandardError = True,
                .CreateNoWindow = True
            }

            Using process As Process = Process.Start(startInfo)

                While Not process.StandardOutput.EndOfStream
                    Dim line As String = process.StandardOutput.ReadLine()
                    ' Handle each line of output as needed.
                    Writelog("    " & line, "INF")
                End While

                Dim errorOutput As String = process.StandardError.ReadToEnd()
                ' Handle the error output stream as needed.
                'If (errorOutput <> "") Then
                '    Writelog("Error Output while compression: " & errorOutput, "INF")
                'Else
                '    Writelog("Compression Complete!", "INF")
                'End If
                Writelog("Compressed Image: " & pOutputFile & vbCrLf, "INF")
            End Using
        Catch ex As Exception
            Writelog("Exception occurred in StartOSGEO4W, ex.message: " & ex.Message, "ERR")
        End Try

    End Sub

    'Public Sub CloseLog()
    '    gobjFS.Close()
    '    gobjFS.Dispose()
    'End Sub

    'Public Sub OpenLog()
    '    Try
    '        gobjFS = File.Open("ImgCompressionUsingQGIS.log", FileMode.Append)
    '    Catch ex As Exception
    '        MsgBox("Error occurred in OpenLog, ex.desc: " & ex.Message)
    '    End Try
    'End Sub

    Public Sub Writelog(ByVal pStr As String, ByVal pType As String)

        Try
            'Using sw As New StreamWriter(gobjFS)

            '    Dim data As Byte() = System.Text.Encoding.UTF8.GetBytes(DateTime.Now.ToLongTimeString & " - " & pType & ": " & pStr)

            '    gobjFS.Write(data, 0, data.Length)

            'End Using

            File.AppendAllText(gLogFileName, DateTime.Now & " -- " & pType & " -- " & pStr & vbCrLf)
        Catch ex As Exception
            MsgBox("Exception occurred in WriteLog, ex.desc: " & ex.Message)
        End Try

    End Sub
End Module
