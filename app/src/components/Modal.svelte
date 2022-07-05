<script lang="ts">
    import { onDestroy } from "svelte";
    import DataStore from "../store";
    import type { User } from "../models/models";

    export let showModal = false;

    let amount: number;
    let totalOrderVolume: number;
    let sharePrice: number;
    let prevAmount = amount;
    let validationError: string;
    let accountBalance: number;
    let user: User;

    const unsub = DataStore.subscribe((data) => {
        sharePrice = data.sharePrice;
        accountBalance = data.accountBalance;
    });

    $: {
        totalOrderVolume = amount * sharePrice;
    }

    const validator = (node, value) => {
        return {
            update(value) {
                amount =
                    value === null || amount < node.min
                        ? prevAmount
                        : parseInt(value);
                prevAmount = amount;
            },
        };
    };

    const validateAmount = () => {
        if (totalOrderVolume > accountBalance) {
            validationError = "You don't have enough money to buy this amount!";
        } else {
            validationError = "";
        }
    };

    const sendOrder = async () => {
        validateAmount();

        const res = await fetch(
            `https://localhost:7120/api/Stock/buy/${amount}`,
            {
                method: "POST",
                mode: "cors",
            }
        );

        user = await res.json();

        DataStore.update((currentData) => {
            return {
                ...currentData,
                accountBalance: user.accountBalance,
                numberOfShares: user.numberOfShares,
                username: user.username,
            };
        });

        amount = 0;
    };

    onDestroy(() => {
        unsub();
    });
</script>

{#if showModal}
    <div class="backdrop" on:click|self>
        <div class="modal">
            <h3>Buy Shares</h3>
            <p>Amount of shares:</p>
            <input
                bind:value={amount}
                type="number"
                use:validator={amount}
                on:input={validateAmount}
                min="1"
            />
            <p>Total Order Volume:</p>
            {#if totalOrderVolume}
                <h3>{totalOrderVolume.toFixed(2)} €</h3>
            {:else}
                <h3>00.00€</h3>
            {/if}
            {#if validationError}
                <p class="error">{validationError}</p>
            {/if}
            <button
                class="btn-primary"
                on:click={sendOrder}
                on:click
                disabled={Boolean(validationError)}>Place Order</button
            >
        </div>
    </div>
{/if}

<style>
    .backdrop {
        position: absolute;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        background-color: rgba(0, 0, 0, 0.8);
        color: white;
        display: grid;
        align-items: center;
    }

    .modal {
        width: 25rem;
        height: min-content;
        display: flex;
        flex-direction: column;
        align-items: center;
        margin: 0 auto;
        padding: 2rem;
        border-radius: 10px;
        background-color: white;
        color: black;
    }

    p {
        margin-bottom: 0;
        margin-top: 1rem;
    }

    .btn-primary {
        margin-top: 2rem;
    }

    .error {
        color: red;
        font-weight: bold;
        text-align: center;
        font-size: 1rem;
        overflow-wrap: break-word;
        max-width: 100%;
    }
</style>
