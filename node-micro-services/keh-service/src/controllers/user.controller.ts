import Router from 'express'
import UserService from '../services/user.service.js'
import { hasGlobalAccess, hasRouteAccess } from '../services/userauthorization.service.js'

const userRouter = Router()
const userService = new UserService()

// user module specific authorizations
userRouter.all('/*', [hasGlobalAccess, hasRouteAccess]);

// to get all users
userRouter.get('/all', (req, res) => {
    const users = userService.getAllUsers()
    res.status(200).json(userService.sortAllUsers(users));
});

// to get all users
userRouter.get('/all2', (req, res) => {
  const users = userService.getAllUsers()
  res.status(200).json(userService.sortAllUsers(users));
});

// to get user by id
userRouter.get('/:id', (req, res) => {
  res.status(200).json(userService.getUserById(Number(req.params.id)));
});

export default userRouter;
