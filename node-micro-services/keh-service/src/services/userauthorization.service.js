export default class UserAuthorizationService {
  constructor(req, res, next) {
    if(this.hasAccess(req)) {
      next(req, res)
    }
    res.end("No Security")
  }

  hasAccess = (req) => {
    return true
  }
}