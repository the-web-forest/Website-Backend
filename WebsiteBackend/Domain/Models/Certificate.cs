using MongoDB.Bson.Serialization.Attributes;

namespace WebsiteBackend.Domain.Models;
public class Certificate : Model
{
    [BsonElement("certificateId")]
    public string CertificateId { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("file")]
    public string File { get; set; }
}
