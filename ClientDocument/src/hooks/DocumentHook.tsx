import { useContext } from "react";
import { DocumentContext } from "../contexts/DocumentContext";

export default function useDocument() {
  const context = useContext(DocumentContext);
  return context;
}
