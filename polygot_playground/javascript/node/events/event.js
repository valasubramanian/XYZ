import EventEmitter from 'events'

const customEvent = new EventEmitter()

customEvent.on('', (obj) => {
    console.log('customEvent is emitted')
})

customEvent.on('profileCreated', (id, profile) => {
    console.log('profileCreated event is emitted', id, profile)
})

customEvent.on('profileUpdated', (id, profile) => {
    console.log('profileCreated event 1 is emitted', id, profile)
})

customEvent.on('profileUpdated', (id, profile) => {
    console.log('profileUpdated event 2 is emitted', id, profile)
})

customEvent.emit('')
customEvent.emit('profileCreated', 0, { name : 'vala' })
customEvent.emit('profileUpdated', 12, { name : 'valasubramanian' })

