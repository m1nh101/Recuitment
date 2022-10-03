import client, { Response } from "./client"

export interface PositionProps{
  id: number
  name: string
}

export const getPositions = async (): Promise<Response<Array<PositionProps>>> => {
  const response = await client.get('/positions')
  return response.data
}