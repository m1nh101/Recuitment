import { AxiosInstance } from "axios";

export interface Response<TData>{
  statusCode: number
  message: string
  data?: TData,
  errors: Array<object | string>
}

const axios = require('axios')

const client: AxiosInstance = axios.create({
  baseURL: `https://localhost:7273/api`
})

export default client;