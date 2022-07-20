import HttpResponseCode from '../http-response-code.js'

export default class AppError extends Error {
    public readonly httpCode: HttpResponseCode;
  
    constructor(description:string, code:HttpResponseCode) {
      super(description);
      Object.setPrototypeOf(this, new.target.prototype);
      this.httpCode = code;
      Error.captureStackTrace(this);
    }
}