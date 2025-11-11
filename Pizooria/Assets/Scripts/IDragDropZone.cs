public interface IDragDropZone
{
    bool CanAccept(IDragObject dragObject);
    void BeginAccepting(IDragObject dragObject);
    void EndAccepting();
    void Accept(IDragObject dragObject);
}