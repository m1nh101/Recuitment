import { UploadFile } from "antd"
import { RcFile } from "antd/lib/upload"
import client from "./client"

export const fileUpload = async (file: File): Promise<string> => {
  const data = new FormData()
  
  data.append('files', file)

  const response = await client.post('/files', data, {
    headers: {
      'Content-Type': 'multipart/form-data'
    }
  })
  return response.data.url;
}