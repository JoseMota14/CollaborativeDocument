import { ReactNode, createContext, useEffect, useState } from "react";
import { Document } from "../models/document";
import { getSignalRConnection } from "../utils/signalRSetup";

interface iDocumentContext {
  document: Document;
  handleInputChange: (e: React.ChangeEvent<HTMLTextAreaElement>) => void;
}

const DocumentContext = createContext({} as iDocumentContext);

interface iAuthProvider {
  children: ReactNode;
}

function DocumentProvider({ children }: iAuthProvider) {
  const [document, setDocument] = useState<Document>({
    id: "SomeDocumentId",
    content: "Initial document content...",
  });
  const signalRConnection = getSignalRConnection();

  useEffect(() => {
    signalRConnection.on("ReceiveUpdatedDocument", (content: any) => {
      console.log(content);

      setDocument((prevDocument) => ({
        ...prevDocument,
        id: content.documentId,
        content: content.newContent,
      }));
    });

    return () => {
      signalRConnection.off("ReceiveUpdatedDocument");
    };
  }, [signalRConnection]);

  const handleInputChange = (e: React.ChangeEvent<HTMLTextAreaElement>) => {
    const newContent = e.target.value;
    setDocument((prevDocument) => ({
      ...prevDocument,
      content: newContent,
    }));
    signalRConnection
      .invoke("UpdateDocument", newContent)
      .catch((error) => console.error(error));
  };

  return (
    <DocumentContext.Provider value={{ document, handleInputChange }}>
      {children}
    </DocumentContext.Provider>
  );
}

export { DocumentContext, DocumentProvider };
