import { useEffect, useState } from "react";
import useDocument from "../../hooks/DocumentHook";
import { DetailContainer, EditorContainer, H2, TextArea } from "./style";

function Editor() {
  const { document, handleInputChange } = useDocument();
  const [documentId, setDocumentId] = useState<string>();

  // const buttons: ButtonInterface[] = [
  //   {
  //     name: "save",
  //   },
  // ];

  useEffect(() => {
    setDocumentId(document.id);
  }, [document]);

  return (
    <EditorContainer>
      <DetailContainer>
        <H2>Id: {documentId}</H2>
      </DetailContainer>
      {/* {buttons.map((el: ButtonInterface) => {
        return <Button key={el.name} name={el.name}></Button>;
      })} */}
      <TextArea onChange={handleInputChange} value={document.content} />
    </EditorContainer>
  );
}

export default Editor;
