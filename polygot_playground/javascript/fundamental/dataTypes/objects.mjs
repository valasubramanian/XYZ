/* 
    Javascript Objects
    cmd: node objects.mjs
*/

// Destructuring assignment
const { address: addressLine } = { address: "20B Rue Lafayette", postcode: "75009" };
const [first, second] = [1, 2, 3, 4]
console.warn("1.0->", addressLine); // 20B Rue Lafayette
console.warn("1.1->", first, second) // 1 2

// Optional Chaining
const contactInfos = { address: { street: "20B Rue Lafayette" } };
console.warn("1.2->", contactInfos.address.street, contactInfos.user?.name)

// Coalescing operator ??  
// it returns his right operator when the left operator is either null or undefined. 
console.warn("2.0->", null ?? "I'm null")
console.warn("2.1->", undefined ?? "I'm undefined")
console.warn("2.2->", contactInfos.user?.name ?? undefined)
console.warn("2.3->", contactInfos.user?.name ?? "I don't have a name")

console.warn("2.4->", undefined && "I'm undefined")
console.warn("2.5->", contactInfos.user?.name && "I don't have a name")
console.warn("2.6->", contactInfos.user?.name && undefined)
console.warn("2.7->", contactInfos.address && contactInfos.address.street)
console.warn("2.7.1->", contactInfos.address.street && contactInfos.address)

console.warn("2.8->", undefined || "I'm defined")
console.warn("2.9->", contactInfos.user?.name || "I have a name")
console.warn("2.10->", contactInfos.user?.name || undefined)
console.warn("2.11->", contactInfos.address || contactInfos.address.street)
console.warn("2.12->", contactInfos.address.street || contactInfos.address)

const userInfo = { name: "Vala" };
const contInfor = undefined
console.log("3.1->", { ...userInfo, contInfor })
console.log("3.2->", { ...userInfo, ...contInfor })
console.log("3.2->", { ...userInfo, ...(contInfor != undefined && contInfor) })