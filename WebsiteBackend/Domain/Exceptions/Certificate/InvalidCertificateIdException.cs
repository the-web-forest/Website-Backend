using System;
using System.Runtime.Serialization;

namespace WebsiteBackend.Domain.Exceptions;

[Serializable]
public class InvalidCertificateIdException : BaseException
{
    public InvalidCertificateIdException()
        : base("001", "Invalid Certificate Id") { }

    protected InvalidCertificateIdException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
}