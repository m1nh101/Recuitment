import client, { Response } from "./client"

export interface LevelProps {
  id: number
  name: string
}

type GetLevelProps = Response<Array<LevelProps>>

export const getLevels = async (): Promise<GetLevelProps> => {
  var response = await client.get('/levels')
  return response.data
}