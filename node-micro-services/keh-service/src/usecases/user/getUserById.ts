import getAllUsers from './getAllUsers.js'

const getUserById = (id:number) => {
    const users = getAllUsers();
    return users.filter((f: { id: number }) => f.id == id)?.at(0)
}

export default getUserById;