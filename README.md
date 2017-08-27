# SPContextHeaders

Extracts SharePoint request cookies out of CSOM ClientContext

```csharp
using System.Net;
using Microsoft.SharePoint.Client;

using (ClientContext context = new ClientContext("http://sharepoint/")) {

    // context.Credentials = <creds ...>;

    WebHeaderCollection headers = ContextHeaders.GetHeaders(options.Context);

    // Auth headers now can be used for authentication using any request library
    // talking to REST, SOAP, etc.

}
```