import { configureStore } from "@reduxjs/toolkit";
import createSagaMiddleware, { SagaMiddleware } from "redux-saga";
import employeeSlice from "./employeeSlice";
import recruitmentSlice from "./recruitmentSlice";
import utilSlice from "./utilSlice";

const sagaMiddleware: SagaMiddleware<object> = createSagaMiddleware()

const store = configureStore({
  reducer: {
    recruitments: recruitmentSlice,
    utils: utilSlice,
    employees: employeeSlice
  }
})


export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch

export default store;