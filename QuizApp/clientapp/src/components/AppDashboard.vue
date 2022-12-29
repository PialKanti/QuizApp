<template>
    <p>Welcome {{ loggedUser.fullName }}</p>
</template>

<script>
export default {
    name: 'AppDashboard',
    data() {
        return {
            loggedUser: {
                firstName: '',
                lastName: '',
                fullName: '',
                email: '',
                userName: '',
                roleName: ''
            }
        };
    },
    async created() {
        this.fetchLoggedUserDetail();
    },
    methods: {
        async fetchLoggedUserDetail() {
            const email = this.$store.state.loggedUserEmail;
            const requestUrl = `api/Account/current-user?email=${email}`;
            const response = await fetch(requestUrl);
            const responseResult = await response.json();

            this.loggedUser.firstName = responseResult.firstName;
            this.loggedUser.LastName = responseResult.lastName;
            this.loggedUser.fullName = this.loggedUser.firstName + " " + this.loggedUser.LastName;
            this.loggedUser.email = responseResult.email;
            this.loggedUser.userName = responseResult.userName;
            this.loggedUser.roleName = responseResult.roleName;

            console.log(this.loggedUser.roleName);
        }
    }
}
</script>