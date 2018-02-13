Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Class clsEncriptador
    Private c_sClaveBase As String = "avz10@pass75dc"
    Private c_sValorSalt As String = "s@lAvz13"
    Private c_iIteraciones As Integer = 1
    Private c_sVectorInit As String = "@1B2c3D4e5F6g7H8"
    Private c_iLongitudLlave As Integer = 128

    Public Function Encriptar(ByVal p_sTextoParaEncriptar As String) As String
        Dim bytesVectorInit As Byte() = Encoding.ASCII.GetBytes(c_sVectorInit)
        Dim bytesValorSalt As Byte() = Encoding.ASCII.GetBytes(c_sValorSalt)
        Dim bytesTextoPlano As Byte() = Encoding.UTF8.GetBytes(p_sTextoParaEncriptar)

        Dim password As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(c_sClaveBase, bytesValorSalt, c_iIteraciones)
        Dim keyBytes As Byte() = password.GetBytes(c_iLongitudLlave / 8)
        Dim symmetricKey As RijndaelManaged = New RijndaelManaged()
        symmetricKey.Mode = CipherMode.CBC
        Dim encryptor As ICryptoTransform = symmetricKey.CreateEncryptor(keyBytes, bytesVectorInit)
        Dim memoryStream As MemoryStream = New MemoryStream()
        Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write)

        cryptoStream.Write(bytesTextoPlano, 0, bytesTextoPlano.Length)
        cryptoStream.FlushFinalBlock()

        Dim bytesTextoCifrado As Byte() = memoryStream.ToArray()

        memoryStream.Close()
        cryptoStream.Close()

        Dim sTextoCifrado As String = Convert.ToBase64String(bytesTextoCifrado)

        Return sTextoCifrado

    End Function

    Public Function Desencriptar(ByVal p_sTextoEncriptado As String) As String
        Dim bytesVectorInit As Byte() = Encoding.ASCII.GetBytes(c_sVectorInit)
        Dim bytesValorSalt As Byte() = Encoding.ASCII.GetBytes(c_sValorSalt)
        Dim bytesTextoCifrado As Byte() = Convert.FromBase64String(p_sTextoEncriptado)

        Dim password As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(c_sClaveBase, bytesValorSalt, c_iIteraciones)
        Dim keyBytes As Byte() = password.GetBytes(c_iLongitudLlave / 8)
        Dim symmetricKey As RijndaelManaged = New RijndaelManaged()
        symmetricKey.Mode = CipherMode.CBC
        Dim decryptor As ICryptoTransform = symmetricKey.CreateDecryptor(keyBytes, bytesVectorInit)
        Dim memoryStream As MemoryStream = New MemoryStream(bytesTextoCifrado)
        Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)
        Dim bytesTextoPlano As Byte()
        ReDim bytesTextoPlano(bytesTextoCifrado.Length)
        Dim decryptedByteCount As Integer = cryptoStream.Read(bytesTextoPlano, 0, bytesTextoPlano.Length)

        memoryStream.Close()
        cryptoStream.Close()

        Dim sTextoPlano As String = Encoding.UTF8.GetString(bytesTextoPlano, 0, decryptedByteCount)

        Return sTextoPlano

    End Function

End Class
