import { NextFunction, Request, Response } from 'express';
import { HttpResponseCode, AppError } from '../common/export.js'

const _hasGlobalAccess = true;
const hasGlobalAccess = (req:Request, res:Response, next:NextFunction) => {
  if(_hasGlobalAccess) {
    console.log('user global access is authorized');
    next();
  }
  else {
    throw new AppError('Unauthorized: No global access', HttpResponseCode.UNAUTHORIZED);
  }
}

const _hasRouteAccess = false;
const hasRouteAccess = (req:Request, res:Response, next:NextFunction) => {
  if(_hasRouteAccess) {
    console.log('user route is authorized');
    next();
  }
  else {
    throw new AppError('Unauthorized: No route access', HttpResponseCode.UNAUTHORIZED);
  }
}

export { hasGlobalAccess, hasRouteAccess };


// export default class UserAuthorizationService {
//   constructor(req:Request, res:Response, next:NextFunction) {
//     if(this.hasAccess(req)) {
//       next()
//     }
//     res.end("No Security")
//   }

//   hasAccess = (req:Request) => {
//     return true
//   }
// }