import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App.tsx";
import { DocumentProvider } from "./contexts/DocumentContext.tsx";
import "./index.css";

ReactDOM.createRoot(document.getElementById("root")!).render(
  <React.StrictMode>
    <DocumentProvider>
      <App />
    </DocumentProvider>
  </React.StrictMode>
);
