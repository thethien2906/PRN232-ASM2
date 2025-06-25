using GraphQL;
using GraphQL.Client.Abstractions;
using HIV_CARE.GraphQLClients.BlazorWAS.ThienTTT.Models;
using static HIV_CARE.GraphQLClients.BlazorWAS.ThienTTT.Models.AppointmentThienTtt;
// This using statement was a bit confusing. It's cleaner to qualify the nested classes when you use them.
// using static HIV_CARE.GraphQLClients.BlazorWAS.ThienTTT.Models.AppointmentThienTtt;

namespace HIV_CARE.GraphQLClients.BlazorWAS.ThienTTT.GraphQlClients
{
    public class GraphQLConsumer
    {
        private readonly IGraphQLClient _graphQLClient;
        public GraphQLConsumer(IGraphQLClient graphQLClient) => _graphQLClient = graphQLClient;

        public async Task<List<AppointmentThienTtt>> GetAppointmentTtts()
        {
            try
            {
                var query = @"query GetAppointmentThienTtts {
                                getAppointmentThienTtts {
                                    appointmentsThienTttid
                                    patientName
                                    appointmentDate
                                    appointmentTime
                                    consultationType
                                    priority
                                    totalFee
                                    status
                                }
                            }";

                var response = await _graphQLClient.SendQueryAsync<AppointmentThienTttsGraphQLResponse>(query);

                return response?.Data?.getAppointmentThienTtts ?? new List<AppointmentThienTtt>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching appointments: {ex.Message}");
                return new List<AppointmentThienTtt>();
            }
        }

        public async Task<AppointmentThienTtt> GetAppointmentThienTttById(int id)
        {
            try
            {
                var graphQLRequest = new GraphQLRequest
                {
                    Query = @"query GetAppointmentThienTttById($id: Int!) {
                                getAppointmentThienTttById(id: $id) {
                                    appointmentsThienTttid
                                    doctorsPhatNhid
                                    patientName
                                    appointmentDate
                                    appointmentTime
                                    estimatedDuration
                                    consultationType
                                    priority
                                    isConfirmed
                                    isCompleted
                                    isAnonymous
                                    totalFee
                                    notes
                                    status
                                    createdDate
                                    createdBy
                                    modifiedDate
                                    modifiedBy
                                }
                            }",
                    Variables = new { id }
                };

                var response = await _graphQLClient.SendQueryAsync<AppointmentThienTttGraphQLResponse>(graphQLRequest);

                return response?.Data?.getAppointmentThienTttById;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching appointment by ID: {ex.Message}");
                return null; 
            }
        }

        public async Task<int> UpdateAppointmentThienTtt(AppointmentThienTtt appointmentThienTtt)
        {
            try
            {
                var graphQLRequest = new GraphQLRequest
                {
                    Query = @"
                        mutation UpdateAppointmentThienTtt($input: AppointmentThienTttInput!) {
                            updateAppointmentThienTtt(appointmentThienTtt: $input)
                        }",
                    Variables = new { input = appointmentThienTtt }
                };

                var response = await _graphQLClient.SendMutationAsync<UpdateAppointmentThienTttGraphQLResponse>(graphQLRequest);

                return response.Data.updateAppointmentThienTtt;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating appointment: {ex.Message}");
                return 0; 
            }
        }

        public async Task<int> CreateAppointmentThienTtt(AppointmentThienTtt appointmentThienTtt)
        {
            try
            {
                var graphQLRequest = new GraphQLRequest
                {
                    Query = @"
                        mutation CreateAppointmentThienTtt($input: AppointmentThienTttInput!) {
                            createAppointmentThienTtt(appointmentThienTtt: $input)
                        }",
                    Variables = new { input = appointmentThienTtt }
                };

                var response = await _graphQLClient.SendMutationAsync<CreateAppointmentThienTttGraphQLResponse>(graphQLRequest);

                return response.Data.createAppointmentThienTtt;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating appointment: {ex.Message}");
                return 0; 
            }
        }

        public async Task<bool> DeleteAppointmentThienTtt(int id)
        {
            try
            {
                var graphQLRequest = new GraphQLRequest
                {
                    Query = @"
                        mutation DeleteAppointmentThienTtt($id: Int!) {
                            deleteAppointmentThienTtt(id: $id)
                        }",
                    Variables = new { id }
                };

                var response = await _graphQLClient.SendMutationAsync<DeleteAppointmentThienTttGraphQLResponse>(graphQLRequest);

                return response.Data.deleteAppointmentThienTtt;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting appointment: {ex.Message}");
                return false; 
            }
        }
    }
}