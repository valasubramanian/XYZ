import Router from 'express'
import UserService from '../services/user.service.js'
import UserAuthorizationService from '../services/userauthorization.service.js'

const userRouter = new Router()
const userService = new UserService()

// to get all users
userRouter.get('/check', [UserAuthorizationService])

// to get all users
userRouter.get('/all',  (req, res, next) => {
    const users = userService.getAllUsers()
    res.json(userService.sortAllUsers(users));
    next()
});

// to get all users
userRouter.get('/all2', (req, res, next) => {
  const users = userService.getAllUsers()
  res.end(userService.sortAllUsers(users));
});

// to get user by id
userRouter.get('/:id', (req, res, next) => {
  res.json(userService.getUserById(req.params.id));
});

export default userRouter;
