import axios from "axios";

export async function post(url: string, endpoint: string, payload: object) {
  try {
    const response = await axios.post(url + endpoint, payload);
    return response.data;
  } catch (error) {
    console.log(error);
  }
}

export async function get(url: string, endpoint: string) {
  try {
    const response = await axios.get(url + endpoint);
    return response.data;
  } catch (error) {
    console.log(error);
  }
}
