<script lang="ts">
    import DataStore from "../store";
</script>

<section>
    <img src="apple.svg" alt="" />
    <h2>Apple</h2>
    <div class="price">{$DataStore.sharePrice} €</div>
    <button class="btn-primary" on:click>Buy</button>
    <p class="own">
        You own {$DataStore.numberOfShares} shares.
    </p>
</section>

<style>
    section {
        max-width: 25rem;
        display: flex;
        flex-direction: column;
        margin: 0 auto;
        padding: 2rem;
        border-radius: 10px;
        box-shadow: rgba(100, 100, 111, 0.4) 0px 7px 29px 0px;
    }

    img {
        max-height: 3rem;
    }

    h2 {
        text-align: center;
        margin-top: 1rem;
    }

    .price {
        font-size: 1.8rem;
        text-align: center;
        margin: 1rem 0rem;
    }

    .own {
        font-size: 1rem;
        margin-top: 1rem;
        margin-bottom: 0;
    }
</style>
