import { NextFunction, Request, Response } from 'express';
import AppError from './app-error.js'

const errorMiddleware = (err:AppError, req:Request, res:Response, next:NextFunction) => {
    return res.status(err.httpCode).end(err.message)
}

export default errorMiddleware;