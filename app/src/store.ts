import { writable } from "svelte/store";

const DataStore = writable({
    username: "Test",
    accountBalance: 0,
    numberOfShares: 0,
    sharePrice: 130
});

export default DataStore;