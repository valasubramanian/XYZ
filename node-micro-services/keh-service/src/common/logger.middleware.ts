import { NextFunction, Request, Response } from 'express';

const loggerMiddleware = (req:Request, res:Response, next:NextFunction) => {
    console.log('NEW REQUEST : ' + req.url)
    next()
}

export default loggerMiddleware;