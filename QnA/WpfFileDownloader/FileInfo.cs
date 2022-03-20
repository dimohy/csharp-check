using System.ComponentModel;

namespace WpfFileDownloader;

public class FileInfo : INotifyPropertyChanged
{
    private long _bytesReceived;
    private long _totalBytesToReceive;
    private DownloadState _downloadState;

    public event PropertyChangedEventHandler? PropertyChanged;

    public string Filename { get; }
    public string OriginUri { get; }
    public long BytesReceived {
        get => _bytesReceived;
        set
        {
            _bytesReceived = value;
            OnPropertyChanged(nameof(BytesReceived));
        }
    }
    public long TotalBytesToReceive
    {
        get => _totalBytesToReceive;
        set
        {
            _totalBytesToReceive = value;
            OnPropertyChanged(nameof(TotalBytesToReceive));
        }
    }

    public DownloadState DownloadState
    {
        get => _downloadState;
        set
        {
            _downloadState = value;
            OnPropertyChanged(nameof(DownloadState));
        }
    }

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public FileInfo(string filename, string originUri)
    {
        this.Filename = filename;
        this.OriginUri = originUri;
    }
}

public enum DownloadState
{
    Wait,
    Downloading,
    DownloadComplete
}
