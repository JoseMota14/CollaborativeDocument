import { HubConnection, HubConnectionBuilder } from "@microsoft/signalr";

let connection: HubConnection | null = null;
let url = import.meta.env.VITE_REACT_APP_API_URL;

export const startSignalRConnection = () => {
  console.log(url);

  connection = new HubConnectionBuilder()
    .withUrl(url + "/documentHub")
    .withAutomaticReconnect()
    .build();

  connection.start().catch((error) => console.error(error));
};

export const getSignalRConnection = () => {
  if (!connection) {
    startSignalRConnection();
  }
  return connection!;
};
