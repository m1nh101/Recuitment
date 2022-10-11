import client, { Response } from "./client"

export interface RoleProps {
  id: string
  name: string
}

export const getRoles = async (): Promise<Response<Array<RoleProps>>> => {
  const response = await client.get('/auth/roles');
  return response.data
}