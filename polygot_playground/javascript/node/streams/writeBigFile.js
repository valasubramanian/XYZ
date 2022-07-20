import { writeFileSync } from 'fs'

for(let i = 0; i < 10000; i++) {
    writeFileSync('./big-file.txt', `hello world ${i}\n`, { flag: 'a' })
}