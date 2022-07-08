export default class UserService {
  getAllUsers = () => {
    return [
      { id: 3, name: 'vala'},
      { id: 5, name: 'subra'},
      { id: 4, name: 'mania'},
      { id: 2, name: 'sunm'},
      { id: 1, name: 'vel'}
    ]
  }
  
  sortAllUsers = (users) => {
    return users.sort((a, b) => a.id - b.id)
  }
  
  getUserById = (id) => {
    const users = getAllUsers()
    return users.filter(f => f.id == id)?.at(0)
  }
}
