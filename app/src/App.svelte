<script lang="ts">
	import { onDestroy, onMount } from "svelte";
	import Header from "./components/Header.svelte";
	import Stock from "./components/Stock.svelte";
	import type { User, Share } from "./models/models";
	import Modal from "./components/Modal.svelte";
	import DataStore from "./store";

	let user: User;
	let share: Share;
	let showModal = false;

	onMount(async () => {
		try {
			let [u, s] = await Promise.all([
				fetch("https://localhost:7120/user"),
				fetch("https://localhost:7120/share"),
			]);

			user = await u.json();
			share = await s.json();

			// update the store
			DataStore.update((currentData) => {
				return {
					accountBalance: user.accountBalance,
					numberOfShares: user.numberOfShares,
					sharePrice: share.sharePrice,
					username: user.username,
				};
			});
		} catch (error) {
			console.error(error);
		}
	});

	const toggleModal = () => {
		showModal = !showModal;
	};
</script>

<Modal {showModal} on:click={toggleModal} />
<Header />
<main>
	<h1>Hello {$DataStore.username}!</h1>
	<p>Your stock pick for the day:</p>
	<Stock on:click={toggleModal} />
</main>

<style>
	h1 {
		text-align: center;
	}

	p {
		margin-bottom: 3rem;
	}

	main {
		text-align: center;
	}
</style>
