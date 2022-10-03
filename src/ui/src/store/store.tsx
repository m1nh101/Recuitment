import { configureStore } from "@reduxjs/toolkit";
import createSagaMiddleware, { SagaMiddleware } from "redux-saga";
import recruitmentSlice from "./recruitmentSlice";

const sagaMiddleware: SagaMiddleware<object> = createSagaMiddleware()

const store = configureStore({
  reducer: {
    recruitments: recruitmentSlice
  }
})


export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch

export default store;