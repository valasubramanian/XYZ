const getAllUsers = () => {
    let users = [
      { id: 3, name: 'vala'},
      { id: 5, name: 'subra'},
      { id: 4, name: 'mania'},
      { id: 2, name: 'sunm'},
      { id: 1, name: 'vel'}
    ]

    users = users.sort((a, b) => a.id - b.id);
    return users;
}

export default getAllUsers