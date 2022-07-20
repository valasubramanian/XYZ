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
  
  sortAllUsers = (users:any) => {
    return users //.sort((a:number, b:number) => a.id - b.id)
  }
  
  getUserById = (id:number) => {
    const users = this.getAllUsers();
    return users.filter((f: { id: number }) => f.id == id)?.at(0)
  }
}
