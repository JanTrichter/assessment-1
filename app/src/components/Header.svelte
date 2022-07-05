<script lang="ts">
    import type { User } from "../models/models";
    import UserStore from "../store";
</script>

<header>
    <div class="container">
        <div class="logo">
            <h2>StockTrader</h2>
        </div>
        <div class="user-container">
            <h5>Balance: {$UserStore.accountBalance}€</h5>
            <h5>{$UserStore.username}</h5>
            <img src="avatar.svg" class="user-img" alt="" />
        </div>
    </div>
</header>

<style>
    .container {
        width: 100%;
        display: flex;
        justify-content: space-between;
        padding: 1.2em 3em;
    }

    .user-container {
        display: flex;
        align-items: center;
    }

    .user-container > *:not(:last-child) {
        margin-right: 2rem;
    }

    .user-img {
        max-width: 3rem;
    }

    header {
        margin-bottom: 3rem;
    }
</style>
