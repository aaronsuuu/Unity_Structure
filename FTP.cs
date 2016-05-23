using System;
using System.Net;
using System.IO;

public class FTPClient
{
    FtpWebRequest request;
    FtpWebResponse response;

    BufferedStream stream;
    MemoryStream ms;
    BufferedStream msStream;

    byte[] buffer = new byte[4096];
    public byte[] raw;
    public long filesize = 0;

    public bool complete;

    public FTPClient(string url, string user, string pass)
    {

        request = WebRequest.Create(url) as FtpWebRequest;
        request.Method = WebRequestMethods.Ftp.DownloadFile;
        request.Credentials = new NetworkCredential(user, pass);
        ms = new MemoryStream();
        complete = false;
    }

    public void Download()
    {
        response = request.GetResponse() as FtpWebResponse;
        stream = new BufferedStream(response.GetResponseStream());
        msStream = new BufferedStream(ms); //Exception.
        stream.BeginRead(buffer, 0, buffer.Length, EndRead, stream);
    }

    public void EndRead(IAsyncResult result)
    {
        int n = stream.EndRead(result);
        filesize += n;
        msStream.Write(buffer, 0, n);
        if (stream.CanRead && n != 0) stream.BeginRead(buffer, 0, buffer.Length, EndRead, stream);
        else
        {
            response.Close();
            stream.Close();
            msStream.Close();
            raw = ms.ToArray();
            ms.Close();
            complete = true;
        }
    }
}
